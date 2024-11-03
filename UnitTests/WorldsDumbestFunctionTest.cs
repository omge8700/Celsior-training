using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public  static class WorldsDumbestFunctionTest
    {
        //Naming conventition-classname_MethodName_ExpectedResult
        public static void  DumbestFunction_ReturnPikachuIfZero_ReturnString()
        {
            try
            {
                //Araange-getiing the variables ,whatever we need classes

                int num = 0;

               

                DumbestFunction wordlsDumbest = new DumbestFunction();
                //Act-Execute this function

                string result = wordlsDumbest.ReturnPikachu(num);
                //Assert -Whatever is returned is what we want
                if (result == "Pickachu")
                {
                    Console.WriteLine("PASSED: worldsDumbest.ReturnPikachu");


                }

                else
                {
                    Console.WriteLine("FAILED: worldsDumbest.ReturnPikachu");
                }

            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }


        }


    }
}
