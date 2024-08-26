using System.IO;
using UnityEngine;

public class VeriYoneticisi : MonoBehaviour
{
    public static VeriYoneticisi Instance;
    private string dosyaYolu;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        // Dosya yolunu belirleme
        dosyaYolu = Application.persistentDataPath + "/oyunverisi.json";
        
        if(File.Exists(dosyaYolu))
        {
            DataSave data = VeriyiYukle();
            GameManager.Instance.coins = data.coinsSave;
            GameManager.Instance.coinText.text = GameManager.Instance.coins.ToString();
            GameManager.Instance.gems = data.gemsSave;
            GameManager.Instance.gemText.text = GameManager.Instance.gems.ToString();
            GameManager.Instance.damage = data.powerSave;
            Upgrades.Instance.upgradeMoney = data.upgradeSave;
            LevelChange.Instance.level = data.inWhichLevelSave;
            LevelChange.Instance.levelText.text = LevelChange.Instance.level.ToString();
            LevelChange.Instance.levelUpButtonCheck = data.maxLevelSave;
            
        }
        
    }

    public void VeriyiKaydet()
    {
        // Oyun verisini s�n�fa atama
        DataSave veri = new DataSave();
        veri.coinsSave = GameManager.Instance.coins;
        veri.gemsSave = GameManager.Instance.gems;
        veri.powerSave = GameManager.Instance.damage;
        veri.upgradeSave = Upgrades.Instance.upgradeMoney;
        veri.inWhichLevelSave = LevelChange.Instance.level;
        veri.maxLevelSave = LevelChange.Instance.levelUpButtonCheck;

        // JSON format�na �evirme
        string json = JsonUtility.ToJson(veri);

        // JSON verisini dosyaya yazma
        File.WriteAllText(dosyaYolu, json);

        Debug.Log("Veri kaydedildi: " + json);
    }

    public DataSave VeriyiYukle()
    {
        // Dosyan�n var olup olmad���n� kontrol etme
        if (File.Exists(dosyaYolu))
        {
            // Dosyadan JSON verisini okuma
            string json = File.ReadAllText(dosyaYolu);

            // JSON verisini s�n�fa �evirme
            DataSave veri = JsonUtility.FromJson<DataSave>(json);

            Debug.Log("Veri y�klendi: " + json);

            return veri;
        }
        else
        {
            Debug.LogWarning("Kay�t dosyas� bulunamad�.");
            return null;
        }
    }

    public void VeriyiSil()
    {
        if (File.Exists(dosyaYolu))
        {
            File.Delete(dosyaYolu);
            Debug.Log("Kay�t dosyas� silindi.");
        }
        else
        {
            Debug.LogWarning("Silinecek dosya bulunamad�.");
        }
    }
}
