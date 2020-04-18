using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        List<string> arrayAlfabeto = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        public string Crypt(string message)
        {
            if (message == null)
                throw new ArgumentNullException();

            if (message == "")
                return "";

            bool existeCaracterEspecial = Regex.IsMatch(message, (@"[!""#$%&'()*+,-./:;?@[\\\]_`{|}~]"));
            if(existeCaracterEspecial)
                throw new ArgumentOutOfRangeException();

            bool existeAcento = Regex.IsMatch(message.ToLower(), (@"[à-ú]"));
            if(existeAcento)
                throw new ArgumentOutOfRangeException();
           

            StringBuilder textoFinal = new StringBuilder(message.ToLower());
            try
            {
                for (int i = 0; i < textoFinal.Length; i++)
                {
                    var aux = textoFinal[i].ToString();

                    if (arrayAlfabeto.IndexOf(aux) > -1)
                    {
                        int posicaoLetra = arrayAlfabeto.IndexOf(aux) + 3;
                        if (posicaoLetra <= -1)
                            posicaoLetra = arrayAlfabeto.Count + posicaoLetra;
                        if ((arrayAlfabeto.Count - 1) < posicaoLetra)
                            posicaoLetra = posicaoLetra - arrayAlfabeto.Count;
                        textoFinal.Remove(i, 1);
                        textoFinal.Insert(i, arrayAlfabeto[posicaoLetra].ToString());
                    }
                }
            }
            catch(Exception ex)
            {


            }
            return textoFinal.ToString();            
            
        }

        public string Decrypt(string cryptedMessage)
        {
            if (cryptedMessage == null)
                throw new ArgumentNullException();

            bool existeCaracterEspecial = Regex.IsMatch(cryptedMessage, (@"[!""#$%&'()*+,-./:;?@[\\\]_`{|}~]"));
            if (existeCaracterEspecial)
                throw new ArgumentOutOfRangeException();

            bool existeAcento = Regex.IsMatch(cryptedMessage.ToLower(), (@"[à-ú]"));
            if (existeAcento)
                throw new ArgumentOutOfRangeException();

            StringBuilder textoFinal = new StringBuilder(cryptedMessage.ToLower());
            for (int i = 0; i < textoFinal.Length; i++)
            {
                var aux = textoFinal[i].ToString();                               

                if (arrayAlfabeto.IndexOf(aux) > -1)
                {
                    int posicaoLetra = arrayAlfabeto.IndexOf(aux) - 3;
                    if (posicaoLetra <= -1)
                        posicaoLetra = arrayAlfabeto.Count + posicaoLetra;
                    textoFinal.Remove(i, 1);
                    textoFinal.Insert(i, arrayAlfabeto[posicaoLetra].ToString());
                }                
            }
            return textoFinal.ToString();
        }
    }
}
