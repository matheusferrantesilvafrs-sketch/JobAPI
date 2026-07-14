using JobAPI.Models;
using JobAPI.Data;

namespace JobAPI.Services
{
    public class CadastroService
    {
        private readonly AppDbContext context;

        public CadastroService(AppDbContext context)
        {
            this.context = context;
        }

        public void Criar(PostDados novoCadastro)
        {
            context.PostDados.Add(novoCadastro);
            context.SaveChanges();
        }

        public void Ler(PostDados novoCadastro)
        {
            foreach (PostDados item in context.PostDados)
            {
                Console.WriteLine($"Id: {item.ID} \nEmpresa: {item.Empresa} \nCargo: {item.Cargo} \nData: {item.Data}  \nObservações: {item.Descrições}");
            }
        }
    }
}