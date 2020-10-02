using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaControle.Core.Models;
using SistemaControle.DataAccess.InMemory;

namespace SistemaControle.WebUI.Controllers
{
    public class ViaturaManagerController : Controller
    {
        ViaturaRepositorio context;

        public ViaturaManagerController()
        {
            context = new ViaturaRepositorio();
        }
        // GET: ViaturaManager
        public ActionResult Index()
        {
            List<Viatura> viaturas = context.Collection().ToList();
            return View(viaturas);
        }

        public ActionResult Create()
        {
            Viatura viatura = new Viatura();
            return View(viatura);
        } 

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create(Viatura viatura)
        {
            if (!ModelState.IsValid)
            {
                return View(viatura);
            }
            else
            {
                context.Insert(viatura);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Viatura viatura = context.Find(Id);
            if(viatura == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(viatura);
            }
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit(Viatura viatura, string Id)
        {
            Viatura viaturaToEdit = context.Find(Id);

            if(viaturaToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(viatura);
                }

                viaturaToEdit.Matricula = viatura.Matricula;
                viaturaToEdit.Marca = viatura.Marca;
                viaturaToEdit.Modelo = viatura.Modelo;
                viaturaToEdit.Categoria = viatura.Categoria;
                viaturaToEdit.Cor = viatura.Cor;
                viaturaToEdit.Cilindrada = viatura.Cilindrada;
                viaturaToEdit.Portas = viatura.Portas;
                viaturaToEdit.Lugares = viatura.Lugares;
                viaturaToEdit.Valores_Aquisicao = viatura.Valores_Aquisicao;
                viaturaToEdit.Data_aquisicao = viatura.Data_aquisicao;
                viaturaToEdit.Estado = viatura.Estado;
                viaturaToEdit.Data_Registo = viatura.Data_Registo;
                viaturaToEdit.Peso_Bruto = viatura.Peso_Bruto;
                viaturaToEdit.Peso_Liquido = viatura.Peso_Liquido;
                viaturaToEdit.Imagem = viatura.Imagem;

                context.Commit();

                return RedirectToAction("Index");
            }

        }
        
        public ActionResult  Delete(string Id)
        {
            Viatura viaturaToDelete = context.Find(Id);
            if(viaturaToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(viaturaToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Viatura viaturaToDelete = context.Find(Id);
            if(viaturaToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        } 
    }
}