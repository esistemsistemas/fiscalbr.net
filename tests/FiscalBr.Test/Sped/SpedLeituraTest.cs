﻿using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace FiscalBr.Test.Sped
{
    public class SpedLeituraTest
    {
        [Fact]
        public void LeituraArquivoEFDContribuicoesSimplesApropriacaoDireta()
        {
            /*
             * http://sped.rfb.gov.br/pagina/show/1609
             */
            var exampleFromSped = 
              @"|0000|002|0|||01042011|30042011|EMPRESA YYY|77777777000191|MG|3106200||00|0|
                |0001|0|
                |0110|1|1|1|
                |0140|1|EMPRESA YYY|77777777000191|MG||3106200|||
                |0990|5|
                |A001|1|
                |A990|2|
                |C001|1|
                |C990|2|
                |D001|1|
                |D990|2|
                |F001|1|
                |F990|2|
                |M001|0|
                |M200|0|0|0|0|0|0|0|0|0|0|0|0|
                |M600|0|0|0|0|0|0|0|0|0|0|0|0|
                |M990|4|
                |1001|1|
                |1990|2|
                |9001|0|
                |9900|0000|1|
                |9900|0001|1|
                |9900|0110|1|
                |9900|0140|1|
                |9900|0990|1|
                |9900|1001|1|
                |9900|1990|1|
                |9900|9001|1|
                |9900|9990|1|
                |9900|9999|1|
                |9900|A001|1|
                |9900|A990|1|
                |9900|C001|1|
                |9900|C990|1|
                |9900|D001|1|
                |9900|D990|1|
                |9900|F001|1|
                |9900|F990|1|
                |9900|M001|1|
                |9900|M200|1|
                |9900|M600|1|
                |9900|M990|1|
                |9900|9900|23|
                |9990|26|
                |9999|45|
                ";

            File.WriteAllText("SpedTest.txt", exampleFromSped);

            var efdContribFile = new FiscalBr.EFDContribuicoes.ArquivoEFDContribuicoes();

            efdContribFile.Ler("SpedTest.txt");

            Assert.Equal("EMPRESA YYY", efdContribFile.Bloco0.Reg0000.Nome);
        }
    }
}
