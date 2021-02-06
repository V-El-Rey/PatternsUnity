using UnityEngine;

public class ShipFactory
{
    private GameObject _shipPrefab;

    private ShipController _shipController;
    private ShipModel _shipModel;
    private ShipView _shipView;

    public static ShipFactory Factory;

    public ShipController CreateAStarship(string typeOfShip, Vector3 spawnPosition)
    {
        _shipPrefab = Object.Instantiate(Resources.Load(typeOfShip) as GameObject);
        _shipPrefab.transform.position = spawnPosition;
        _shipModel = new ShipModel();
        _shipView = _shipPrefab.GetComponent<ShipView>();
        return _shipController = new ShipController(_shipView, _shipModel);
    }
    
}
