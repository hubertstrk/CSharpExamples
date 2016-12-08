using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;

namespace Dictionary
{
    public class TranslationController : ApiController
    {
        public string Get()
        {
            var result = DictionaryRepository.Instance.GetTranslations();
            return ToJson( result );
        }

        public string Get( string filter, string language )
        {
            string respone = string.Empty;
            if ( language.Equals( "german" ) )
            {
                var result = DictionaryRepository.Instance.GetTranslations().Where( s => s.German.Contains( filter ) );
                respone = ToJson( result );
            }
            else if ( language.Equals( "english" ) )
            {
                var result = DictionaryRepository.Instance.GetTranslations().Where( s => s.English.Contains( filter ) );
                respone = ToJson( result );
            }
            return respone;
        }

        private string ToJson( IEnumerable<Translation> toConvert )
        {
            MemoryStream stream = new MemoryStream();
            foreach ( var translation in toConvert )
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer( typeof( Translation ) );
                ser.WriteObject( stream, translation );
            }
            return Encoding.Default.GetString( stream.ToArray() );
        }
    }
}
