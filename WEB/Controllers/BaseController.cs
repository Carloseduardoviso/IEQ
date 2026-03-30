using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEB.Controllers
{
    public class BaseController : Controller
    {
        protected List<SelectListItem> GetEstados(string? selecionado = null)
        {
            var lista = new List<SelectListItem>
    {
        new SelectListItem { Text = "Selecione", Value = "" },

        new SelectListItem { Text = "Acre (AC)", Value = "AC" },
        new SelectListItem { Text = "Alagoas (AL)", Value = "AL" },
        new SelectListItem { Text = "Amapá (AP)", Value = "AP" },
        new SelectListItem { Text = "Amazonas (AM)", Value = "AM" },
        new SelectListItem { Text = "Bahia (BA)", Value = "BA" },
        new SelectListItem { Text = "Ceará (CE)", Value = "CE" },
        new SelectListItem { Text = "Distrito Federal (DF)", Value = "DF" },
        new SelectListItem { Text = "Espírito Santo (ES)", Value = "ES" },
        new SelectListItem { Text = "Goiás (GO)", Value = "GO" },
        new SelectListItem { Text = "Maranhão (MA)", Value = "MA" },
        new SelectListItem { Text = "Mato Grosso (MT)", Value = "MT" },
        new SelectListItem { Text = "Mato Grosso do Sul (MS)", Value = "MS" },
        new SelectListItem { Text = "Minas Gerais (MG)", Value = "MG" },
        new SelectListItem { Text = "Pará (PA)", Value = "PA" },
        new SelectListItem { Text = "Paraíba (PB)", Value = "PB" },
        new SelectListItem { Text = "Paraná (PR)", Value = "PR" },
        new SelectListItem { Text = "Pernambuco (PE)", Value = "PE" },
        new SelectListItem { Text = "Piauí (PI)", Value = "PI" },
        new SelectListItem { Text = "Rio de Janeiro (RJ)", Value = "RJ" },
        new SelectListItem { Text = "Rio Grande do Norte (RN)", Value = "RN" },
        new SelectListItem { Text = "Rio Grande do Sul (RS)", Value = "RS" },
        new SelectListItem { Text = "Rondônia (RO)", Value = "RO" },
        new SelectListItem { Text = "Roraima (RR)", Value = "RR" },
        new SelectListItem { Text = "Santa Catarina (SC)", Value = "SC" },
        new SelectListItem { Text = "São Paulo (SP)", Value = "SP" },
        new SelectListItem { Text = "Sergipe (SE)", Value = "SE" },
        new SelectListItem { Text = "Tocantins (TO)", Value = "TO" }
    };

            if (!string.IsNullOrEmpty(selecionado))
            {
                lista.ForEach(x => x.Selected = x.Value == selecionado);
            }

            return lista;
        }

        [HttpGet]
        public async Task<JsonResult> GetCidades(string uf)
        {
            using var http = new HttpClient();

            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{uf}/municipios";

            var response = await http.GetStringAsync(url);

            var cidades = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(response);

            var lista = cidades!.Select(c => new {
                id = (string)c.nome,
                text = (string)c.nome
            });

            return Json(lista);
        }
    }
}