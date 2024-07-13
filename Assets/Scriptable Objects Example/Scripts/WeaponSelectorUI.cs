using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectorUI : MonoBehaviour
{
    [SerializeField] private WeaponSelector weaponSelector;

    [SerializeField] private GameObject weaponUI;
    
    [Header("Weapon Button Panel")] 
    [SerializeField] private WeaponButton weaponButtonPrefab;
    [SerializeField] private Transform weaponButtonPanel;

    [Header("Weapon Info Display")] 
    [SerializeField] private TMP_Text txtName;
    [SerializeField] private TMP_Text txtDescription;
    [SerializeField] private TMP_Text txtDamage;
    [SerializeField] private TMP_Text txtStrength;
    [SerializeField] private TMP_Text txtReload;
    [SerializeField] private Image imgWeapon;
    
    private void OnEnable()
    {
        weaponSelector.OnWeaponLoaded += PopulateWeaponButton;
        weaponSelector.OnWeaponSelected += PopulateWeaponSelection;
    }

    private void OnDisable()
    {
        weaponSelector.OnWeaponLoaded -= PopulateWeaponButton;
        weaponSelector.OnWeaponSelected -= PopulateWeaponSelection;
    }

    private void PopulateWeaponButton(WeaponDataSO weaponData)
    {
        var newButton = Instantiate(weaponButtonPrefab, weaponButtonPanel);
        newButton.SetButton(weaponData);
        
        // Set the event listener to the button to select the weapon
        var button = newButton.GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            Debug.Log("Button Pressed!");
            weaponSelector.SelectWeapon(weaponData);
        } );
    }

    private void PopulateWeaponSelection(WeaponDataSO weaponData)
    {
        txtName.text = weaponData.weaponName;
        txtDescription.text = weaponData.weaponDescription;
        txtDamage.text = $"Damage: {weaponData.damage}";
        txtStrength.text = $"Strength: {weaponData.strength}";
        txtReload.text = $"Reload Speed: {weaponData.reloadSpeed}";
        imgWeapon.sprite = weaponData.sprite;
    }

    public void ToggleWeaponUI()
    {
        CleanWeaponInfo();
        weaponUI.SetActive(!weaponUI.activeSelf);
    }

    private void CleanWeaponInfo()
    {
        txtName.text = "Select Weapon";
        txtDescription.text = "";
        txtDamage.text = "";
        txtStrength.text = "";
        txtReload.text = "";
        imgWeapon.sprite = null;
    }
}
