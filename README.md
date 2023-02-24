# MeetingApp

-Proje ilk açıldığında Account sayfası karşılıyor burada register ve login olmak üzere iki seçenek mevcut. 
-Register yapıldığında kullanılan girilen maile bir hoşgeldiniz maili atılıyor ve register yapılırken profil fotoğrafı ekleme seçeneği mevcut.
-Eklenen fotoğraf database'e ziplenip kaydoluyor.
-Register olduktan sonra login yaptığımızda bizi meeting sayfası karşılıyor. 
-Burada yeni toplantı eklenebiliyor ve eklenen toplantılar tüm userlara değil toplantıyı oluşturan ve toplantı katılımcılarına gözüküyor.
-Aynı şekilde toplantı oluşturma sırasında da döküman eklenebiliyor, eklenen döküman sıkıştırılıp kaydoluyor.
-Toplantı eklerken aynı zamanda Meeting ile Userları tutan 3. tablo olan MeetingParticipant tablosuna ekleme yapılıyor.
-Toplantı eklendiği zaman katılımcılara toplantı bilgilendirme maili gidiyor.
-Logout butonuyla oturumdan çıkış yapılıyor.
-JWT Auth desteği var.
-Kullanıcı parolaları hashli bir şekilde tutuluyor.
-Tüm CRUD işlemleri api kısmında bulunmakla beraber web tarafında yalnızca Register, Login ve Meeting ekleme bulunmaktadır.
-Meeting güncelleme, silme önyüzde bulunmamaktadır. 

