using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobAPI.Data;
using JobAPI.Models;

namespace JobAPI.Services
{
    public class Dadosdecadastro
    {
        public PostDados cad()
        {

            PostDados cadastro = new PostDados();

            Console.WriteLine("Digite o nome da empresa:");
            cadastro.Empresa = Console.ReadLine();
            Console.Clear();
    

       
            Console.WriteLine("Digite o cargo da vaga:");
            cadastro.Cargo = Console.ReadLine();
            Console.Clear();
        

    
            Console.WriteLine("Digite a plataforma que ofertou a vaga:");
            cadastro.Descrições = Console.ReadLine(); 
            Console.Clear();
            
        

       
            Console.WriteLine("Digite a data de candidatura:");
            string data = Console.ReadLine();
            cadastro.Data  = DateTime.Parse(data);
            Console.Clear();

            return cadastro;
        }
    }
}