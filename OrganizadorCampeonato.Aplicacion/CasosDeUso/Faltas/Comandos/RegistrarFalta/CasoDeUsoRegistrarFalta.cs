using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Faltas.Comandos.RegistrarFalta
{
    public class CasoDeUsoRegistrarFalta : IRequestHandler<ComandoRegistrarFalta, Guid>
    {
        private readonly IRepositorioFalta repositorio;
        private readonly IRepositorioJugadorPartido repositorioJugadorPartido;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoRegistrarFalta(
            IRepositorioFalta repositorio,
            IRepositorioJugadorPartido repositorioJugadorPartido,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.repositorioJugadorPartido = repositorioJugadorPartido;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<Guid> Handle(ComandoRegistrarFalta request)
        {
            var jugadorPartido = await repositorioJugadorPartido.ObtenerPorId(request.JugadorPartidoId);
            if (jugadorPartido is null)
                throw new ExcepcionDeValidacion("No se encontro la relacion jugador-partido");

            // Regla FIBA: 5 faltas personales o 1 descalificante = expulsión
            var faltasActuales = jugadorPartido.Faltas.Count;
            if (request.Tipo == Dominio.Enum.TipoFalta.Descalificante)
                throw new ExcepcionReglaDeNegocio("Falta descalificante registrada. El jugador ha sido expulsado.");
            
            if (faltasActuales >= 5 && request.Tipo == Dominio.Enum.TipoFalta.Personal)
                throw new ExcepcionReglaDeNegocio("El jugador ya tiene 5 faltas y ha sido expulsado.");

            var falta = new Falta(
                Guid.CreateVersion7(),
                request.JugadorPartidoId,
                request.Tipo,
                request.Periodo,
                request.Minuto,
                request.NumeroFalta);

            try
            {
                var respuesta = await repositorio.Agregar(falta);
                await unidadDeTrabajo.Persistir();
                return respuesta.Id;
            }
            catch (Exception)
            {
                await unidadDeTrabajo.Reversar();
                throw;
            }
        }
    }
}
