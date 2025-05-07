Projeyi çalıştırmak için:

Projeyi klonlayınız.
Projede bulunan appsettings.json kısmından SqlServer bağlantı dizesini kendi local veritabanı bağlantınız ile değiştiriniz.
Projedeki WebAPI üzerinde sağ tıklayıp Set as Startup Project'e tıklayın.
Daha sonra Package Manager Console'u açınız ve Default Project kısmını Persistence olarak değiştiriniz.
update-database komutu ile veritabanını kurunuz.

Veritabanına 2 adet seed data eklenmiş olacak. Bunlar, Employee ve Admin data'ları.

Admin'in giriş bilgileri:
UserName = "admin"
Password = "Admin12345"

Employee'nin giriş bilgileri:
UserName = "admin"
Password = "Emp1234567"

![DbDiagram](https://github.com/user-attachments/assets/529c3d42-01b6-4b17-ab93-0305fca0bed4)
