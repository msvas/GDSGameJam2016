using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetInfo {
    public Vector3 coordinates;
    public float radius;

    public PlanetInfo(Vector3 c, float r) {
        this.coordinates = c;
        this.radius = r;
    }
}

public class Creation : MonoBehaviour {

    public int maxSizeX, maxSizeY;
    [Range(0.5f, 1.5f)]
    public float maxRadius;
    public int planetsNumber;
    public int spaceBetweenPlanets;

    private List<PlanetInfo> planets;

	// Use this for initialization
	void Start () {
        planets = new List<PlanetInfo>();

        for (int i = 0; i < planetsNumber; i++) {
            float radius = Random.Range(0.5f, maxRadius);
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

    private bool PlanetsCollide(Vector3 checkedCoord, float radius) {
        bool collides = false;
        foreach(PlanetInfo planet in planets) {
            float distance = Vector3.Distance(planet.coordinates, checkedCoord);
            float minPossible = ((planet.radius * 10) + (radius * 10) + spaceBetweenPlanets);
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
            float newScale = (10f * planet.radius) / 0.5f;
            Debug.Log(planet.radius);
            newPlanet.transform.localScale = new Vector3(newScale, newScale, newScale);
        }
    }

    private void DebugPlanets() {
        foreach(PlanetInfo planet in planets) {
            Debug.Log(planet.coordinates);
        }
    }
}
