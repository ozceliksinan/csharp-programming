using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; 

namespace SystemXMLKullanimi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dosya yeri belirtildi.
            XmlTextWriter XmlText = new XmlTextWriter(@"c:\XML\Personellerim.xml", System.Text.UTF8Encoding.UTF8); 
            // xml version ve encoding kısmı oluşturuldu. Dosyanın header kısmı gibi düşünülebilir --> 1.Part

            XmlText.WriteComment("Xml İşlemleri"); // Yorum yazdırma işlemi
            XmlText.WriteStartElement("Personellerim"); // Başlangıç düğümümüz.

            XmlText.WriteStartElement("Personel");
            XmlText.WriteAttributeString("ID", "1");
            XmlText.WriteElementString("Isim", "sinan");
            XmlText.WriteElementString("Soyisim", "deneme");
            XmlText.WriteElementString("EmailAdres", "info@sinanozcelik.com");
            XmlText.WriteEndElement();

            XmlText.WriteStartElement("Personel");
            XmlText.WriteAttributeString("ID", "2");
            XmlText.WriteElementString("Isim", "deneme");
            XmlText.WriteElementString("Soyisim", "sinan");
            XmlText.WriteElementString("EmailAdres", "info@sinanozcelik.com");
            XmlText.WriteEndElement();

            XmlText.WriteEndElement();
            XmlText.Close(); // Oluşturulan dosya kaydedildi.

            /* Koddaki XML yapısı aşağıdaki gibidir:
             * 
             * <?xml version="1.0" encoding="UTF-8"?>  -->1. Part
             *  <!-- Yorum Satırı: XML İşlemleri -->
             *  <Personeller>
             *      <Personel ID="1">
             *          <isim>sinan</isim>
             *          <Soyisim>deneme</Soyisim>
             *          <EmailAdres>info@sinanozcelik.com</EmailAdres>
             *      </Personel>
             *      <Personel ID="2">
             *          <isim>deneme</isim>
             *          <Soyisim>sinan</Soyisim>
             *          <EmailAdres>info@sinanozcelik.com</EmailAdres>
             *      </Personel>
             * </Personeller>
            */

            // Consol aracılığı ile oluşturulan xml dosyasını okumak için;
            XmlReader XRead = XmlReader.Create(@"C:\XML\Personellerim.xml");
            while (XRead.Read())
            {
                Console.WriteLine($"{XRead.Name.ToString()} - {XRead.Value.ToString()}");
            }
            Console.ReadLine();
        }
    }
}
