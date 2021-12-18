using System.Diagnostics;
using System.Numerics;

//Autor : Bruno Gonçalves Barros
/*
 c# e a arquiteura .net 6

Para executar os algoritmos

 baixar sdk .net 6 
 link: https://dotnet.microsoft.com/en-us/download/dotnet/6.0
 abrir a pasta do projeto com Visual Studio Code ou powershell ou cmd;
 e no terminal executar o comando dotnet build e depois o dotnet run.
 
*/



        // O algoritmo Grade shool
static long DivideMult( long a , long b)
{
    
      //  verificação da quantidade de digitos
    if ( NumeroDigit(a) < 2 || NumeroDigit(b) < 2 )
    {
        
        return  a * b; // retornando a multiplicação

    }

    else
    {
        
        var n =  (Max(a,b)); // Ver maior digito entre o A e B

        var m = (long)Math.Ceiling((decimal)n/2); // Faz divisão do valor maximo do digito e faz arredondamento
               
        
        long aLeft =  DividirDigito(a,m,1); // faz separação do lado esquerdo de a

        long aRight =  DividirDigito(a,m,2); // faz separação do lado direito de a

        long bLeft =  DividirDigito(b,m,1); // faz separação do lado esquerdo de b

        long bRight =  DividirDigito(b,m,2); // faz separação do lado direito de b

   
            //Recursividade
        var  x1 = DivideMult(aLeft,bLeft);
        
        var x2 = DivideMult(aLeft, bRight);

        var x3 = DivideMult(aRight, bLeft);

        var x4 = DivideMult (aRight, bRight);

       

     
                    //cálculo final
        var result = (x1 *  Math.Pow(10,((double)m*2))) + ((x2 + x3) * Math.Pow(10, (double)m))  + x4 ;

        return  (long)result;
        

    }


}


        // o algoritmo Karatsuba
    static ulong Karatsuba(long a , long b)
    {
            //  verificação da quantidade de digitos
         if ( NumeroDigit(a) < 2|| NumeroDigit(b) < 2 )
        {
       
            return (ulong) (a * b); //retornando a multiplicação

        }   

        else
        {

           var n =  (Max(a,b)) ; // Ver maior digito entre o A e B

           var m = (long)Math.Ceiling((decimal)n/2); // Faz divisão do valor maximo do digito e faz arredondamento
                    
                    
            long aLeft =  DividirDigito(a,m,1); // faz separação do lado esquerdo de a

            long aRight =  DividirDigito(a,m,2); // faz separação do lado direito de a

            long bLeft =  DividirDigito(b,m,1); // faz separação do lado esquerdo de b

            long bRight = DividirDigito(b,m,2); // faz separação do lado direito de b

                    //Recursividade
            var  x1 = Karatsuba(aLeft,bLeft);
        
            var x2 = Karatsuba(aLeft + aRight, bLeft + bRight);

            var x3 = Karatsuba(aRight, bRight);
                    
                    //cálculo final
            var result = ( x1 * Math.Pow(10,(double)(m*2))) + ((x2 - x1 - x3) * Math.Pow(10,(double) m)) + x3;
            
            return (ulong)result;

        }
        
    }


        //Numero de digitos
        static long NumeroDigit(long a) 
        {

          return  (long)Math.Floor(Math.Log10(a) + 1 ); //quantidade de digito de um  valor


        }


        //ver o valor com maior digito
        static long Max( long x , long y )
        {
            //quantidade de digito de um  valor a
            var a = Math.Floor(Math.Log10(x) + 1 );
            //quantidade de digito de um  valor b
            var b = Math.Floor(Math.Log10(y) + 1 );


            return (long)Math.Max(a, b);
        }


           //faz divisão dos valores de acordo opção
         static long DividirDigito( long a, long m, int opcão)
        {
            //faz divisão dos valores de acordo opção

            if (opcão == 1) //opção do lado esquerdo 
            {
                return  (long)(Math.Floor(a / (Math.Pow(10,m))));

            }
            else //opção do lado direita  
            {
                return  (long)(a % (Math.Pow(10,m)));

            }
        }




    // Fase de teste do Algoritmo 
    
    // declarando variável para calcular o tempo de execução
    var watch = new Stopwatch();


    
    // arrays com os números para teste
    long[]  vetor1 = {1,25,358,4582,85514,110112,2055101,45000125, 257130001, 1500589011};
    long[] vetor2 = {9, 99, 932, 9554, 45515, 458415, 5485415, 2220056, 12525548, 14410411};
    
    
    
     Console.WriteLine("Multiplicação de inteiros grandes");
    // teste do algoritmo Karatsuba
    Console.WriteLine();
    Console.WriteLine("Karatsuba");
    Console.WriteLine("_________________________________________________________________________");
    Console.WriteLine();

    for(int i = 0; i < vetor1.Length; i ++ )
    {
        Console.WriteLine("Complexidade de dígitos: " + (i + 1));
        
        Console.WriteLine("Primeiro Valor: " + vetor1[i]);
        
        Console.WriteLine("Segundo Valor: " + vetor2[i]);

        watch.Start();// Responsável de salvar tempo de execução do Algoritmo
        Console.WriteLine("Resultado: " + Karatsuba(vetor1[i],vetor2[i]));
        watch.Stop(); //Responsável de parar tempo de execução

        Console.WriteLine("Tempo gasto: " + watch.ElapsedMilliseconds.ToString() + " milisegundos" );
        Console.WriteLine();

    }

    
    


    Console.WriteLine();
    Console.WriteLine("_________________________________________________________________________");
    
        // teste do algoritmo Grade shool
    Console.WriteLine("Grade shool");
    Console.WriteLine();

    for(int i = 0; i < vetor1.Length; i ++ )
    {
        Console.WriteLine("Complexidade de dígitos: " + (i + 1));
        
        Console.WriteLine("Primeiro Valor: " + vetor1[i]);
        
        Console.WriteLine("Segundo Valor: " + vetor2[i]);
          
        watch.Start(); // Responsável de salvar tempo de execução do Algoritmo
        Console.WriteLine("Resultado: " + DivideMult(vetor1[i],vetor2[i]));
        watch.Stop(); // Responsável de parar tempo de execução 

        Console.WriteLine("Tempo gasto: " + watch.ElapsedMilliseconds.ToString() + " milisegundos" );
        Console.WriteLine();

    }






