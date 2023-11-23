using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unieja.Api.Model;
using Unieja.Api.Models;

namespace Unieja.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FaleConoscoController : ControllerBase
    {
        ConfigEmail mailUtils = new ConfigEmail();

        [HttpPost]
        public string EnviarFaleConosco([FromBody] FaleConoscoModel model)
        {
            string retorno = string.Empty;

            bool emailEnviado = mailUtils.EmailEnviado(model.Email, "Cadastro Fale Conosco site unieja.com.br Nome: " +
                             model.Nome + " Cidade: " + model.Cidade +
                             " Estado: " + model.Estado +
                             " Assunto: " + model.Assunto, MontarCorpoEmail(model), " envio e-mail menu Fale Conosco");

            try
            {
                using (UniejaContext ctx = new UniejaContext())
                {
                    Faleconosco f = new Faleconosco
                    {
                        Nome = model.Nome,
                        Telefone = model.Telefone,
                        Celular = model.Celular,
                        Email = model.Email,
                        Cidade = model.Cidade,
                        Estado = model.Estado,
                        Assunto = model.Assunto,
                        Mensagem = model.Mensagem,
                    };

                    ctx.Faleconoscos.Add(f);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                retorno = "Falha ao enviar e-mail!";
                return retorno;
            }

            if (emailEnviado == true)
            {
                retorno = "E-mail enviado com sucesso!";
            }
            else
            {
                retorno = "Falha ao enviar e-mail!";
            }
            return retorno;
        }

        private string MontarCorpoEmail(FaleConoscoModel model)
        {
            string layoutEmail = string.Empty;


            layoutEmail += mailUtils.GetItemLabelValueEmail("Data do Cadastro", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + " " +
                                                                                 Convert.ToDateTime(DateTime.Now.ToShortTimeString()).ToString("HH:mm:ss"));
            layoutEmail += mailUtils.GetItemLabelValueEmail("Nome", model.Nome);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Telefone", model.Telefone);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Celular", model.Celular);
            layoutEmail += mailUtils.GetItemLabelValueEmail("E-mail", model.Email);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Cidade", model.Cidade);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Estado", model.Estado);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Assunto", model.Assunto);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Mensagem", "\r\n"+ model.Mensagem);

            var email = mailUtils.GetBodyEmail(
                "Cadastro Fale Conosco site unieja.com.br Nome: " +
                                        model.Nome + " Cidade: " + model.Cidade +
                                        " Estado: " + model.Estado, layoutEmail);


            return email;
        }
    }
}
