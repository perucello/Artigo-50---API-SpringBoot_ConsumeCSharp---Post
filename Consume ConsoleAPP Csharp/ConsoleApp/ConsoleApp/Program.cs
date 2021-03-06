using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; //importar biblioteca Client
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //Testando Console Basico
            Console.WriteLine("Testando C# - EducaCiencia FastCode");
            Console.ReadLine();
            */

            
            //PostAPI_Java
            PostAPI_Java();
            Console.ReadKey();
  
        }

        

        //Post API Java SpringBoot - WebRequest
        public static void PostAPI_Java()
        {
            string endpointPost = "http://127.0.0.1:8080/api/JPA/clientes/add/";
            WebRequest request = WebRequest.Create(endpointPost);
            request.Method = "POST";
            request.ContentType = "application/json; charset=UTF-8";
            string json = 
                "{" +
                "\"nome\":\"EducacienciaFastCode\"," +
                "\"email\":\"Educaciencia@FastCode.com.br\"" +
                "}";

            var byteArray = Encoding.UTF8.GetBytes(json);
            request.ContentLength = byteArray.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(byteArray, 0, byteArray.Length);
            stream.Close();

            var response = (HttpWebResponse)request.GetResponse();
            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("Post  => ok");
                Console.WriteLine(json);
            }
            else
            {
                Console.Write("fail Post");
            }
        }

        
    }
}
