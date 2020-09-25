using SistemaControle.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace SistemaControle.DataAccess.InMemory
{
    public class ViaturaRepositorio
    {
        ObjectCache cache = MemoryCache.Default;
        List<Viatura> viaturas = new List<Viatura>();    

        public ViaturaRepositorio()
        {
            viaturas = cache["viaturas"] as List<Viatura>;
            if(viaturas == null)
            {
                viaturas = new List<Viatura>();
            }
        }

        public void Commit()
        {
            cache["viaturas"] = viaturas;
        }

        public void Insert(Viatura v)
        {
            viaturas.Add(v);
        }

        public void Update(Viatura viatura)
        {
            Viatura viaturaToUpdate = viaturas.Find(v => v.Viatura_ID == viatura.Viatura_ID);

            if (viaturaToUpdate != null)
            {
                viaturaToUpdate = viatura;
            }
            else
            {
                throw new Exception("Viatura não encontrado");
            }
        }

        public Viatura Find(string Viatura_ID)
        {
            Viatura viatura = viaturas.Find(v => v.Viatura_ID == Viatura_ID);

            if(viatura != null)
            {
                return viatura;
            }
            else
            {
                throw new Exception("Viatura não Encontrado");
            }
        }

        public IQueryable<Viatura> Collection()
        {
            return viaturas.AsQueryable();
        }

        public void Delete(string Viatura_Id)
        {
            Viatura viaturaTuDelete = viaturas.Find(v => v.Viatura_ID == Viatura_Id);

            if(viaturaTuDelete != null)
            {
                viaturas.Remove(viaturaTuDelete); 
            }
            else
            {
                throw new Exception("Viatura não encontrado");
            }

        }
    }
}
