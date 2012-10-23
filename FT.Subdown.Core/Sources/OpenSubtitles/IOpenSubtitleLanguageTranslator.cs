using System;
using System.Globalization;
using OSDBnet;

namespace FT.Subdown.Core.Sources.OpenSubtitles
{
    public interface IOpenSubtitleLanguageTranslator
    {
        string Convert(CultureInfo language);
    }

    public class OpenSubtitleLanguageTranslator : IOpenSubtitleLanguageTranslator
    {
        public string Convert(CultureInfo language)
        {
            if (language.ThreeLetterISOLanguageName == "fra")
                return "fre";

            return language.ThreeLetterISOLanguageName;

            //Albanian
            //alb
            //Arabic
            //ara
            //Armenian
            //arm
            //Basque
            //baq
            //Bengali
            //ben
            //Bosnian
            //bos
            //Portuguese-BR
            //pob
            //Breton
            //bre
            //Bulgarian
            //bul
            //Catalan
            //cat
            //Chinese
            //chi
            //Croatian
            //hrv
            //Czech
            //cze
            //Danish
            //dan
            //Dutch
            //dut
            //English
            //eng
            //Esperanto
            //epo
            //Estonian
            //est
            //Finnish
            //fin
            //French
            //fre
            //Galician
            //glg
            //Georgian
            //geo
            //German
            //ger
            //Greek
            //ell
            //Hebrew
            //heb
            //Hindi
            //hin
            //Hungarian
            //hun
            //Icelandic
            //ice
            //Indonesian
            //ind
            //Italian
            //ita
            //Japanese
            //jpn
            //Kazakh
            //kaz
            //Khmer
            //khm
            //Korean
            //kor
            //Latvian
            //lav
            //Lithuanian
            //lit
            //Luxembourgish
            //ltz
            //Macedonian
            //mac
            //Malay
            //may
            //Mongolian
            //mon
            //Norwegian
            //nor
            //Occitan
            //oci
            //Farsi
            //per
            //Polish
            //pol
            //Portuguese
            //por
            //Romanian
            //rum
            //Russian
            //rus
            //Serbian
            //scc
            //Sinhalese
            //sin
            //Slovak
            //slo
            //Slovenian
            //slv
            //Spanish
            //spa
            //Swahili
            //swa
            //Swedish
            //swe
            //Syriac
            //syr
            //Tagalog
            //tgl
            //Thai
            //tha
            //Turkish
            //tur
            //Ukrainian
            //ukr
            //Urdu
            //urd
            //Vietnamese
            //vie
            //End

        }

    }
}
