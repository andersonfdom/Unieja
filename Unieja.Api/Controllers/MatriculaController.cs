using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unieja.Api.Model;
using Unieja.Api.Models;

namespace Unieja.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        ConfigEmail mailUtils = new ConfigEmail();

        [HttpPost]
        public string EnviarMatricula([FromBody] MatriculaModel model)
        {
            string retorno = string.Empty;

            bool emailEnviado = mailUtils.EmailEnviado(model.Email, "Matrícula site unieja.com.br Aluno: " +
            model.Nome + " Unidade: " + model.AgenciadorPolo +
            " Curso: " + model.Curso, MontarCorpoEmail(model),
            " envio e-mail menu Matricule-se");

            try
            {
                using (UniejaContext ctx = new UniejaContext())
                {
                    Matricula m = new Matricula
                    {
                        Nome = model.Nome,
                        Formainvestimento = model.FormaInvestimento,
                        Datanascimento = model.DataNascimento,
                        Datapagamento = model.DataPagamento,
                        Agenciadorpolo = model.AgenciadorPolo,
                        Curso = model.Curso,
                        Rg = model.Rg,
                        Cpf = model.Cpf,
                        Whatsapp = model.WhatsApp,
                        Logradouro = model.Logradouro,
                        Cep = model.Cep,
                        Complemento = model.Complemento,
                        Bairro = model.Bairro,
                        Cidade = model.Cidade,
                        Estado = model.Estado,
                        Email = model.Email,
                        Nomeresponsavel = model.NomeResponsavel,                        
                        Emailresponsavel = model.EmailResponsavel,
                        Telefoneresponsavel = model.TelefoneResponsavel,
                        Cpfresponsavel = model.CpfResponsavel,
                        Nomemae = model.NomeMae
                    };

                    ctx.Matriculas.Add(m);
                    ctx.SaveChanges();

                    retorno = "E-mail enviado com sucesso!";
                }
            }
            catch (Exception)
            {
                retorno = "Falha ao enviar e-mail!";
                return retorno;
            }

            return retorno;
        }

        private string MontarCorpoEmail(MatriculaModel model)
        {
            string layoutEmail = string.Empty;

            layoutEmail += mailUtils.GetItemLabelValueEmail("Data da Matrícula", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy") + " " +
                                                                                 Convert.ToDateTime(DateTime.Now.ToShortTimeString()).ToString("HH:mm:ss"));

            layoutEmail += mailUtils.GetItemLabelValueEmail("Nome do Aluno", model.Nome);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Forma de Investimento", model.FormaInvestimento);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Data de Nascimento", model.DataNascimento);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Data de Pagamento", model.DataPagamento);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Unidade", model.AgenciadorPolo);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Curso", model.Curso);
            layoutEmail += mailUtils.GetItemLabelValueEmail("RG", model.Rg);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Cpf", model.Cpf);
            layoutEmail += mailUtils.GetItemLabelValueEmail("WhatsApp", model.WhatsApp);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Logradouro", model.Logradouro);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Cep", model.Cep);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Complemento", model.Complemento);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Bairro", model.Bairro);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Cidade", model.Cidade);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Estado", model.Estado);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Email", model.Email);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Nome do Responsável", model.NomeResponsavel);
            layoutEmail += mailUtils.GetItemLabelValueEmail("E-mail do Responsável", model.EmailResponsavel);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Telefone do Responsável", model.TelefoneResponsavel);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Cpf do Responsável", model.CpfResponsavel);
            layoutEmail += mailUtils.GetItemLabelValueEmail("Nome da Mãe", model.NomeMae);

            var email = mailUtils.GetBodyEmail( "Matrícula site unieja.com.br Aluno: " + model.Nome, layoutEmail);

            return email;
        }
    }
}
