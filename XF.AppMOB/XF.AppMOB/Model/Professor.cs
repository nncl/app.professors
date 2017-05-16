using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF.AppMOB.Model
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }

    // Toda parte de comunicacao com a base de dados fica aqui
    public class ProfessorRepository
    {
        private static List<Professor> professoresSqlAzure;

        public static async Task<List<Professor>> GetProfessoresSqlAzureAsync()
        {
            if (professoresSqlAzure != null) return professoresSqlAzure;

            var httpRequest = new HttpClient();
            var stream = await httpRequest.GetStreamAsync(
                "");

            var professorSerializer = new DataContractJsonSerializer(typeof(List<Professor>));
            professoresSqlAzure = (List<Professor>)professorSerializer.ReadObject(stream);

            return professoresSqlAzure;
        }
    }
}
