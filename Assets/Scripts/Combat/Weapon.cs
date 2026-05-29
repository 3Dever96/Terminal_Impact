using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Database/Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public int weaponIndex;
    public int clipSize;
    public float bulletSpeed;
    public float fireRate;
    public float reloadTime;
    public int bulletDamage;
}
