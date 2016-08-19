using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetInfo {
    public Vector3 coordinates;
    public int radius;

    public PlanetInfo(Vector3 c, int r) {
        this.coordinates = c;
        this.radius = r;
    }
}

public class Creation : MonoBehaviour {

    public int maxSizeX, maxSizeY;
    public int maxRadius;
    public int planetsNumber;
    public int spaceBetweenPlanets;

    private List<PlanetInfo> planets;

	// Use this for initialization
	void Start () {
        planets = new List<PlanetInfo>();

        for (int i = 0; i < planetsNumber; i++) {
            int radius = Random.Range(1, maxRadius);
            Vector3 coordinates = RandomCoordinates();
            while (PlanetsCollide(coordinates, radius)) {
                coordinates = RandomCoordinates();
            }
            planets.Add(new PlanetInfo(coordinates, radius));
        }
        CreatePlanets();
        //DebugPlanets();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private Vector3 RandomCoordinates() {
            return new Vector3(Random.Range(0, maxSizeX), Random.Range(0, maxSizeY), 0f);
    }

    private bool PlanetsCollide(Vector3 checkedCoord, int radius) {
        bool collides = false;
        foreach(PlanetInfo planet in planets) {
            float distance = Vector3.Distance(planet.coordinates, checkedCoord);
            float minPossible = (planet.radius + radius + spaceBetweenPlanets);
            //Debug.Log(distance);
            //Debug.Log(minPossible);
            if (distance < minPossible) {
                collides = true;
            }
        }
        return collides;
    }

    private void CreatePlanets() {
        foreach (PlanetInfo planet in planets) {
            GameObject newPlanet = (GameObject)Instantiate(Resources.Load("PlanetBase"));
            newPlanet.transform.position = planet.coordinates;
        }
    }

    private void DebugPlanets() {
        foreach(PlanetInfo planet in planets) {
            Debug.Log(planet.coordinates);
        }
    }
}
