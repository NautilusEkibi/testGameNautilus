using System.Collections.Generic;

public static class DersSecimVerisi
{
    public const int Fen = 1;
    public const int Matematik = 2;
    public const int Turkce = 3;
    public const int LiseFizik = 4;
    public const int LiseKimya = 5;
    public const int LiseMatematik = 6;
    public const int LiseBiyoloji = 7;

    // 0=belli değil, sınıf=5-8, ünite ve alt konu numaraları 1’den başlar.
    public static int SeciliDers { get; private set; }
    public static int SeciliSinif { get; private set; }
    public static int SeciliUnite { get; private set; }
    public static int SeciliAltKonu { get; private set; }
    public static bool OrtaokulMu { get; private set; } = true;
    public static bool AltKonuEkraniAcik { get; private set; }

    public static void DersiSec(int ders, bool ortaokulMu)
    {
        SeciliDers = ders;
        OrtaokulMu = ortaokulMu;
        SeciliSinif = 0;
        UniteListesineDon();
    }

    public static bool SinifiSec(int sinif)
    {
        if (OrtaokulMu && (sinif < 5 || sinif > 8)) return false;
        if (!OrtaokulMu && (sinif < 9 || sinif > 12)) return false;
        SeciliSinif = sinif;
        UniteListesineDon();
        return true;
    }

    public static bool UniteyiSec(int unite)
    {
        if (!OrtaokulMu || SeciliDers < Fen || SeciliDers > Turkce || SeciliSinif < 5 || SeciliSinif > 8) return false;
        if (DersIcerikKatalogu.Bul(SeciliDers, SeciliSinif, unite) == null) return false;
        SeciliUnite = unite;
        SeciliAltKonu = 0;
        AltKonuEkraniAcik = true;
        return true;
    }

    public static bool AltKonuyuSec(int altKonu)
    {
        if (!AltKonuEkraniAcik) return false;
        string[] konular = DersIcerikKatalogu.AltKonuBasliklari(SeciliDers, SeciliSinif, SeciliUnite);
        if (konular == null || altKonu < 1 || altKonu > konular.Length) return false;
        SeciliAltKonu = altKonu;
        return true;
    }

    public static void UniteListesineDon()
    {
        SeciliUnite = 0;
        SeciliAltKonu = 0;
        AltKonuEkraniAcik = false;
    }

    public static void AnaMenuyeDon()
    {
        SeciliDers = 0;
        SeciliSinif = 0;
        OrtaokulMu = true;
        UniteListesineDon();
    }

    public static string[] SeciliAltKonuBasliklari()
    {
        return DersIcerikKatalogu.AltKonuBasliklari(SeciliDers, SeciliSinif, SeciliUnite);
    }
}

public sealed class UniteIcerigi
{
    public int UniteNo { get; private set; }
    public string Baslik { get; private set; }
    public string[] AltKonular { get; private set; }

    public UniteIcerigi(int uniteNo, string baslik, string[] altKonular)
    {
        UniteNo = uniteNo;
        Baslik = baslik;
        AltKonular = altKonular;
    }
}

public static class DersIcerikKatalogu
{
    private static readonly Dictionary<int, UniteIcerigi> Kayitlar = new Dictionary<int, UniteIcerigi>
    {
        {10501, new UniteIcerigi(1, "Gökyüzündeki Komşularımız ve Biz", new string[] {"Gökyüzündeki Komşumuz: Güneş", "Gökyüzündeki Komşumuz: Ay", "Dünyamız ve gökyüzündeki komşularımız"})},
        {10502, new UniteIcerigi(2, "Kuvveti Tanıyalım", new string[] {"Kuvvet ve Kuvvetin ölçülmesi", "Kütle ve Ağırlık İlişkisi", "Sürtünme Kuvveti"})},
        {10503, new UniteIcerigi(3, "Canlıların Yapısına Yolculuk", new string[] {"Hücre ve Organelleri", "Destek ve Hareket Sistemi"})},
        {10504, new UniteIcerigi(4, "Işığın Dünyası", new string[] {"Işığın Yayılması", "Maddenin Işığı Geçirgenliği", "Tam Gölgenin oluşumu"})},
        {10505, new UniteIcerigi(5, "Maddenin Doğası", new string[] {"Maddenin tanecikli yapısı", "Isı ve Sıcaklık", "Maddenin hal değişimi", "Madde ve Isı"})},
        {10506, new UniteIcerigi(6, "Yaşamımızdaki Elektrik", new string[] {"Devre elemanlarının sembolleri ve şeması", "Basit bir elektrik devresinde ampulün parlaklığını etkileyen faktörler"})},
        {10507, new UniteIcerigi(7, "Sürdürülebilir Yaşam ve Geri dönüşüm", new string[] {"Evrensel Atıklar ve geri dönüşüm"})},
        {10601, new UniteIcerigi(1, "Güneş sistemi ve tutulmalar", new string[] {"Güneş sistemi", "Güneş ve ay tutulmaları"})},
        {10602, new UniteIcerigi(2, "Kuvvetin etkisinde hareket", new string[] {"Bileşke kuvvet", "Sabit süratli ve sabit hızlı hareket"})},
        {10603, new UniteIcerigi(3, "Canlılarda sistemler", new string[] {"Bitki ve hayvanlarda üreme, büyüme ve gelişme", "Denetleyici ve düzenleyici sistemler"})},
        {10604, new UniteIcerigi(4, "Işığın yansıması ve renkler", new string[] {"Işığın yansıması", "Aynalar", "Işığın soğrulması"})},
        {10605, new UniteIcerigi(5, "Maddenin ayırt edici özellikleri", new string[] {"Genleşme ve büzüşme", "Maddenin hal değişim noktaları", "Yoğunluk"})},
        {10606, new UniteIcerigi(6, "Elektriğin iletimi ve direnç", new string[] {"Elektriğin iletimi", "Elektriksel direnç ve bağlı olduğu faktörler"})},
        {10607, new UniteIcerigi(7, "Sürdürülebilir yaşam ve etkileşim", new string[] {"Biyoçeşitlilik", "İnsan ve çevre etkileşimi"})},
        {10701, new UniteIcerigi(1, "Uzay Çağı", new string[] {"Türkiye ve uzay araştırmaları", "Uzay teknolojileri ve gözlem araçları", "Uzayda neler var? (Yıldızlar, galaksiler, evren)"})},
        {10702, new UniteIcerigi(2, "Kuvvet ve enerjiyi keşfedelim", new string[] {"Kuvvet, iş ve enerji ilişkisi", "Kinetik ve potansiyel enerji", "Enerji dönüşümleri ve enerjinin korunumu"})},
        {10703, new UniteIcerigi(3, "Vücudumuzdaki sistemler", new string[] {"Sindirim, dolaşım, solunum ve boşaltım sistemleri", "Sistemlerin sağlığı, kan ve organ bağışı"})},
        {10704, new UniteIcerigi(4, "Işığın kırılması ve mercekler", new string[] {"Işığın kırılması", "Mercekler ve kullanım alanları"})},
        {10705, new UniteIcerigi(5, "Maddenin doğasına yolculuk", new string[] {"Maddenin tanecikli yapısı (Atom, element, bileşik)", "Saf maddeler ve karışımlar", "Karışımların ayrılması yöntemleri"})},
        {10706, new UniteIcerigi(6, "Elektriklenme", new string[] {"Elektrik yükleri ve elektriklenme çeşitleri", "Elektroskop ve topraklama"})},
        {10707, new UniteIcerigi(7, "Sürdürülebilir yaşam ve enerji", new string[] {"Besin zinciri ve enerji akışı", "Sürdürülebilir yaşam ve çevre bilinci"})},
        {10801, new UniteIcerigi(1, "Mevsimler ve iklim", new string[] {"Mevsimlerin oluşumu", "İklim ve hava hareketleri", "Küresel iklim değişikliği"})},
        {10802, new UniteIcerigi(2, "Yaşamı kolaylaştıran kuvvet", new string[] {"Basit makineler ve iş kolaylığı (Makaralar, kaldıraçlar, eğik düzlem)", "Günlük yaşamda basit makinelerin kullanımı", "Basınç"})},
        {10803, new UniteIcerigi(3, "Yaşamın gizemi", new string[] {"DNA ve genetik kod", "Kalıtım (Tek karakter çaprazlamaları)", "Mutasyon, modifikasyon ve adaptasyon", "Biyoteknoloji ve genetik mühendisliği"})},
        {10804, new UniteIcerigi(4, "Sesin dünyası", new string[] {"Sesin yayılma hızı ve özellikleri (Frekans, genlik)", "Ses dalgaları ve teknolojideki uygulamaları"})},
        {10805, new UniteIcerigi(5, "Periyodik tablo ve maddenin etkileşimi", new string[] {"Periyodik sistem ve elementlerin sınıflandırılması", "Fiziksel ve kimyasal değişimler", "Kimyasal tepkimeler", "Asitler ve bazlar"})},
        {10806, new UniteIcerigi(6, "Elektriğin yolculuğu", new string[] {"Elektrik enerjisinin dönüşümü (Isı, ışık, hareket)", "Elektrik enerjisi üretim santralleri ve tasarruf"})},
        {10807, new UniteIcerigi(7, "Sürdürülebilir yaşam ve madde döngüleri", new string[] {"Madde döngüleri (Su, karbon, azot döngüsü)", "Sürdürülebilir kalkınma ve ekolojik ayak izi"})},
        {20501, new UniteIcerigi(1, "Sayılar ve Nicelikler", new string[] {"Doğal Sayılar ve Basamak Değeri", "Doğal Sayılarla Dört İşlem", "Kesirler ve Kesirlerle İşlemler", "Ondalık Gösterim", "Yüzdeler"})},
        {20502, new UniteIcerigi(2, "İşlemlerle Cebirsel Düşünme", new string[] {"Sayı ve Şekil Örüntüleri", "Eşitlik ve Denklem Öncesi Düşünme"})},
        {20503, new UniteIcerigi(3, "Geometrik Şekiller", new string[] {"Temel Geometrik Kavramlar ve Çizimler", "Açılar ve Açı Ölçme", "Çokgenler ve Üçgen/Dörtgen Çeşitleri"})},
        {20504, new UniteIcerigi(4, "Geometrik Nicelikler", new string[] {"Uzunluk ve Zaman Ölçme", "Dikdörtgenin Alanı ve Çevresi", "Geometrik Cisimler ve Hacim"})},
        {20505, new UniteIcerigi(5, "İstatistiksel Araştırma Süreci", new string[] {"Araştırma Sorusu Oluşturma ve Veri Toplama", "Sıklık Tablosu ve Sütun Grafiği"})},
        {20506, new UniteIcerigi(6, "Veriden Olasılığa", new string[] {"Olaylar ve Olasılık Sezgisi"})},
        {20601, new UniteIcerigi(1, "Sayılar ve Nicelikler: Çarpanlar ve Katlar", new string[] {"Doğal Sayıların Çarpanları ve Katları", "Bölünebilme Kuralları", "Asal Sayılar ve Asal Çarpanlar", "Ortak Bölenler ve Ortak Katlar"})},
        {20602, new UniteIcerigi(2, "Kümeler ve Tam Sayılar", new string[] {"Kümeler ve Gösterimi", "Tam Sayılar ve Sayı Doğrusu", "Mutlak Değer"})},
        {20603, new UniteIcerigi(3, "Kesirler ve Ondalık Gösterim", new string[] {"Kesirlerle Dört İşlem", "Ondalık Gösterimlerle İşlemler"})},
        {20604, new UniteIcerigi(4, "Oran ve Cebirsel İfadeler", new string[] {"Oran Kavramı", "Cebirsel İfadeler ve Örüntüler"})},
        {20605, new UniteIcerigi(5, "Geometrik Şekiller ve Açılar", new string[] {"Açılar (Ters, Yöndeş, İç Ters Açılar)", "Çokgenler ve Dörtgenler"})},
        {20606, new UniteIcerigi(6, "Geometrik Nicelikler ve Alan", new string[] {"Üçgen ve Paralelkenarın Alanı", "Alan Ölçü Birimleri", "Çemberin Çevresi"})},
        {20607, new UniteIcerigi(7, "İstatistik ve Olasılık", new string[] {"İkili Sütun Grafiği ve Veri Analizi", "Deneysel Olasılık"})},
        {20701, new UniteIcerigi(1, "Tam Sayılar ve Rasyonel Sayılar", new string[] {"Tam Sayılarla Dört İşlem", "Rasyonel Sayılar ve Sayı Doğrusu", "Rasyonel Sayılarla İşlemler"})},
        {20702, new UniteIcerigi(2, "Cebirsel İfadeler ve Denklemler", new string[] {"Cebirsel İfadelerle İşlemler", "Eşitliğin Korunumu ve Denklem Kurma", "Birinci Dereceden Bir Bilinmeyenli Denklemler"})},
        {20703, new UniteIcerigi(3, "Oran, Orantı ve Yüzdeler", new string[] {"Doğru ve Ters Orantı", "Orantı Sabiti ve Problemleri", "Yüzdeler ve Yüzde Problemleri"})},
        {20704, new UniteIcerigi(4, "Doğrular, Açılar ve Çokgenler", new string[] {"Paralel Doğruların Kesenle Yaptığı Açılar", "Düzgün Çokgenler ve Açı Bağıntıları", "Özel Dörtgenler ve Alanları"})},
        {20705, new UniteIcerigi(5, "Çember, Daire ve Cisimler", new string[] {"Çemberde Merkez Açı ve Yay Uzunluğu", "Daire Diliminin Alanı", "Geometrik Cisimlerin Görünümleri"})},
        {20706, new UniteIcerigi(6, "Dönüşüm Geometrisi", new string[] {"Koordinat Sisteminde Öteleme ve Yansıma"})},
        {20707, new UniteIcerigi(7, "İstatistik ve Veri Analizi", new string[] {"Çizgi Grafiği ve Daire Grafiği", "Aritmetik Ortalama, Ortanca ve Tepe Değer"})},
        {20801, new UniteIcerigi(1, "Çarpanlar, Katlar ve Üslü İfadeler", new string[] {"Çarpanlar ve Katlar (EBOB - EKOK)", "Aralarında Asal Sayılar", "Üslü İfadeler ve İşlemler", "Bilimsel Gösterim"})},
        {20802, new UniteIcerigi(2, "Kareköklü İfadeler ve Gerçek Sayılar", new string[] {"Tam Kare Sayılar ve Karekök Alma", "Kareköklü İfadelerle İşlemler", "Gerçek Sayılar"})},
        {20803, new UniteIcerigi(3, "Veri Analizi ve Olasılık", new string[] {"Grafik Türlerinin Dönüşümü", "Basit Olayların Olma Olasılığı"})},
        {20804, new UniteIcerigi(4, "Cebirsel İfadeler, Özdeşlikler ve Denklemler", new string[] {"Cebirsel İfadeler ve Özdeşlikler", "Çarpanlara Ayırma", "Doğrusal Denklemler ve Eğim", "Birinci Dereceden Bir Bilinmeyenli Eşitsizlikler"})},
        {20805, new UniteIcerigi(5, "Üçgenler ve Benzerlik", new string[] {"Üçgende Kenarortay, Açıortay ve Yükseklik", "Üçgen Eşitsizliği ve Pisagor Bağıntısı", "Eşlik ve Benzerlik"})},
        {20806, new UniteIcerigi(6, "Dönüşüm Geometrisi", new string[] {"Koordinat Sisteminde Öteleme ve Yansıma"})},
        {20807, new UniteIcerigi(7, "Geometrik Cisimler", new string[] {"Dik Prizmaların Özellikleri ve Açınımı", "Dik Dairesel Silindirin Alan ve Hacmi", "Dik Piramit ve Dik Koninin Elemanları"})},
        {30501, new UniteIcerigi(1, "Oyun Dünyası", new string[] {"Sözcükte Anlam (Gerçek, Mecaz ve Terim)", "Eş ve Zıt Anlamlı Sözcükler", "Dinleme ve Okuduğunu Anlama"})},
        {30502, new UniteIcerigi(2, "Atatürk ü Tanımak", new string[] {"Cümlede Anlam (Neden-Sonuç, Amaç-Sonuç)", "Kök ve Ek Kavramı (Yapım ve Çekim Ekleri)", "Büyük Harflerin Kullanımı"})},
        {30503, new UniteIcerigi(3, "Duygularımı Tanıyorum", new string[] {"Varlıkların Adları (İsimler / Adlar)", "Somut, Soyut, Tekil, Çoğul ve Topluluk İsimleri", "Öznel ve Nesnel Yargılar"})},
        {30504, new UniteIcerigi(4, "Geleneklerimiz", new string[] {"İsmin Yerini Tutan Sözcükler (Zamirler)", "Metin Türleri (Hikâye, Masal, Şiir)", "Noktalama İşaretleri (Nokta, Virgül, Noktalı Virgül)"})},
        {30505, new UniteIcerigi(5, "İletişim ve Sosyal İlişkiler", new string[] {"Paragrafta Anlam (Ana Fikir ve Yardımcı Fikirler)", "Deyimler ve Atasözleri", "İki Nokta, Üç Nokta ve Soru İşareti"})},
        {30506, new UniteIcerigi(6, "Sağlıklı Yaşıyorum", new string[] {"Metin İçi Karşılaştırmalar ve Örtülü Anlam", "Yay Ayraç, Tırnak ve Kısa Çizgi", "Yazım Kuralları (de, ki, mi yazımı)"})},
        {30601, new UniteIcerigi(1, "Dilimizin Zenginliği", new string[] {"Sözcükte Yapı (Basit, Türemiş, Birleşik)", "İsim ve Fiil Kökleri", "Deyimler, Atasözleri ve Özdeyişler"})},
        {30602, new UniteIcerigi(2, "Bağımsızlık Yolu", new string[] {"Sıfatlar (Niteleme ve Belirtme Sıfatları)", "Cümlede Anlam İlişkileri (Koşul-Sonuç)", "Metnin Ana Düşüncesi ve Konusu"})},
        {30603, new UniteIcerigi(3, "Farklı Dünyalar", new string[] {"Zamirler (Kişi, İşaret, Belgisiz, Soru Zamirleri)", "Söz Sanatları (Kişileştirme, Benzetme)", "Metin Türleri (Fabl, Anı, Mektup)"})},
        {30604, new UniteIcerigi(4, "İletişim ve Sosyal İlişkiler", new string[] {"Edat, Bağlaç ve Ünlem", "Paragrafta Yapı (Giriş, Gelişme, Sonuç)", "Yazımı Karıştırılan Sözcükler"})},
        {30605, new UniteIcerigi(5, "Bilim ve Teknoloji", new string[] {"Cümlenin Temel Ögeleri (Yüklem ve Özne)", "Bilgilendirici Metinleri Yorumlama", "Sayıların ve Kısaltmaların Yazımı"})},
        {30606, new UniteIcerigi(6, "Lider Ruhlar", new string[] {"Anlatıcı Türleri ve Bakış Açıları", "Noktalama İşaretleri (Kesme, Tırnak, Yay Ayraç)", "Yazım ve İmla Kuralları"})},
        {30701, new UniteIcerigi(1, "Hayat Boyu Gelişim", new string[] {"Fiiller (İş, Oluş ve Durum Fiilleri)", "Fiillerde Kip ve Kişi (Haber ve Dilek Kipleri)", "Sözcükte ve Söz Öbeklerinde Anlam"})},
        {30702, new UniteIcerigi(2, "Bir Hilal Uğruna", new string[] {"Fiillerde Anlam (Zaman) Kayması", "Ek Fiil (İsme ve Fiile Gelen Ek Fiil)", "Cümlede Anlam (Örtülü Anlam, Duygu Cümleleri)"})},
        {30703, new UniteIcerigi(3, "İletişim ve Sosyal İlişkiler", new string[] {"Zarflar (Durum, Zaman, Miktar, Yer-Yön, Soru)", "Paragrafta Anlam ve Anlatım Biçimleri", "Düşünceyi Geliştirme Yolları"})},
        {30704, new UniteIcerigi(4, "Türk Sanatı", new string[] {"Fiillerde Yapı (Basit, Türemiş, Birleşik)", "Anlamlarına Göre Cümleler", "Söz Sanatları (Tezat, Abartma)"})},
        {30705, new UniteIcerigi(5, "Okuma Kültürü", new string[] {"Metin Türleri (Söyleşi, Biyografi, Günlük)", "Geçiş ve Bağlantı İfadeleri", "Noktalama İşaretleri"})},
        {30706, new UniteIcerigi(6, "Hak ve Sorumluluklar", new string[] {"Cümlenin Ögeleri (Özne, Yüklem, Nesne, Tümleç)", "Yazım Kuralları ve Anlatım Akıcılığı", "Metin Analizi ve Eleştirel Okuma"})},
        {30801, new UniteIcerigi(1, "İletişim ve Sosyal İlişkiler", new string[] {"Fiilimsiler (İsim-fiil, Sıfat-fiil, Zarf-fiil)", "Fiilimsilerin Cümledeki Görevleri", "Sözcükte Anlam ve Söz Sanatları"})},
        {30802, new UniteIcerigi(2, "Vatan Sevgisi", new string[] {"Cümlenin Ögeleri (Temel ve Yardımcı Ögeler)", "Cümlede Vurgu ve Ara Söz", "Paragrafta Anlam ve Yapı"})},
        {30803, new UniteIcerigi(3, "Doğa ve İnsan", new string[] {"Fiilde Çatı (Öznesine ve Nesnesine Göre)", "Cümle Türleri (Yüklemine, Yerine, Anlamına Göre)", "Metin Türleri (Makale, Deneme, Fıkra)"})},
        {30804, new UniteIcerigi(4, "Türk Hikâye Geleneği ve Destanları", new string[] {"Cümle Türleri (Yapısına Göre: Tek Yüklemli, Fiilimsili, Bağlı, Sıralı)", "Edebi Metin Analizi (Destan, Efsane)", "Yazım Kuralları (Birleşik Sözcükler)"})},
        {30805, new UniteIcerigi(5, "Sanat ve Estetik", new string[] {"Noktalama İşaretleri ve Uygulamaları", "Görsel Okuma, Grafik ve Tablo Yorumlama", "Mantık ve Muhakeme Soruları"})},
        {30806, new UniteIcerigi(6, "Akademik Düşünme Dünyası", new string[] {"Anlatım Bozuklukları (Anlamsal ve Yapısal)", "Metinler Arası Karşılaştırma", "Çıkarım Yapma ve Eleştirel Düşünme"})},
    };

    public static UniteIcerigi Bul(int ders, int sinif, int uniteNo)
    {
        UniteIcerigi icerik;
        return Kayitlar.TryGetValue(Anahtar(ders, sinif, uniteNo), out icerik) ? icerik : null;
    }

    public static int UniteSayisi(int ders, int sinif)
    {
        int adet = 0;
        for (int unite = 1; unite <= 7; unite++)
            if (Bul(ders, sinif, unite) != null) adet++;
        return adet;
    }

    public static string UniteBasligi(int ders, int sinif, int uniteNo)
    {
        UniteIcerigi icerik = Bul(ders, sinif, uniteNo);
        return icerik == null ? string.Empty : icerik.Baslik;
    }

    public static string[] AltKonuBasliklari(int ders, int sinif, int uniteNo)
    {
        UniteIcerigi icerik = Bul(ders, sinif, uniteNo);
        return icerik == null ? new string[0] : icerik.AltKonular;
    }

    public static int AltKonuSayisi(int ders, int sinif, int uniteNo)
    {
        return AltKonuBasliklari(ders, sinif, uniteNo).Length;
    }

    public static string DersAdi(int ders)
    {
        switch (ders)
        {
            case DersSecimVerisi.Fen: return "Fen Bilimleri";
            case DersSecimVerisi.Matematik: return "Matematik";
            case DersSecimVerisi.Turkce: return "Türkçe";
            case DersSecimVerisi.LiseFizik: return "Fizik";
            case DersSecimVerisi.LiseKimya: return "Kimya";
            case DersSecimVerisi.LiseMatematik: return "Matematik";
            case DersSecimVerisi.LiseBiyoloji: return "Biyoloji";
            default: return "Ders";
        }
    }

    private static int Anahtar(int ders, int sinif, int uniteNo)
    {
        return ders * 10000 + sinif * 100 + uniteNo;
    }
}
