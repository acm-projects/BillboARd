using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToURL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void btnTrailer()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=hAUTdjf9rko");
    }

    public void btnReview()
    {
        Application.OpenURL("https://www.rottentomatoes.com/m/it_2017");
    }

    public void btnShowtimes()
    {
        Application.OpenURL("https://www.fandango.com/it-2017-199151/movie-overview");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
