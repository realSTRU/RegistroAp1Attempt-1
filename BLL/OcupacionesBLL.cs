using Microsoft.EntityFrameworkCore;
public class OcupacionesBLL{

    private Contexto _contexto;


    public OcupacionesBLL(Contexto contexto){

        this._contexto= contexto;
    }

    public bool Existe(int ocupacionId){

        return _contexto.Ocupaciones.Any(o => o.OcupacionId == ocupacionId);
    }

    private bool Insertar(Ocupaciones Ocupacion){

        _contexto.Ocupaciones.Add(Ocupacion);

        var insertado = _contexto.SaveChanges() > 0;

        _contexto.Entry(Ocupacion).State = EntityState.Detached;
        return insertado;

    }


    private bool Modificar(Ocupaciones Ocupacion){

        _contexto.Entry(Ocupacion).State= EntityState.Modified;
        
        var modificado = _contexto.SaveChanges() > 0;

        _contexto.Entry(Ocupacion).State = EntityState.Detached;

        return modificado;

    }

    public bool Guardar(Ocupaciones Ocupacion){

        if(!Existe(Ocupacion.OcupacionId))
            return this.Insertar(Ocupacion);
        else
            return this.Modificar(Ocupacion);
    }

    public bool Eliminar(Ocupaciones Ocupacion){

        _contexto.Entry(Ocupacion).State = EntityState.Deleted;
        _contexto.Database.ExecuteSqlRaw($"DELETE FROM Ocupaciones  WHERE OcupacionID={Ocupacion.OcupacionId};");
        bool paso = _contexto.SaveChanges() > 0;
        _contexto.Entry(Ocupacion).State = EntityState.Detached;
        Console.WriteLine($"{paso}");

        return paso;
    }

   

    public Ocupaciones? Buscar(int ocupacionID){

        var buscada = _contexto.Ocupaciones
        .Where(o => o.OcupacionId == ocupacionID)
        .AsNoTracking()
        .SingleOrDefault();

        return buscada;

    }

    public List<Ocupaciones> GetList(){
        return _contexto.Ocupaciones.ToList();
    }
}