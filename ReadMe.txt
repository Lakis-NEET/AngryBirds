Muhammad Nasik Iqbal/463

Dalam game angry bird ini saya menambah:
1. Bird dengan kemampuan bisa membesar ketika di klik

Kode Script OrangeBird:
public class OrangeBird : Bird
{
    public override void OnTap()
    {
        Big();
    }

    public void Big()
    {
        float newScale = Mathf.Lerp(1, 3, 1);
        transform.localScale = new Vector3(newScale, newScale, 1);
        //transform.localScale += new Vector3(2.0f, 2.0f, 0f);
    }
}

2. Stop Condition ketika semua enemy habis dan ketika semua burung habis

Kode Script GameController:
.
.
.
[SerializeField] private GameObject _panel;
.
.
.
 public void ChangeBird()
    {
        TapCollider.enabled = false;

        if (_isGameEnded)
        {
            return;
        }

        Birds.RemoveAt(0);

        if (Birds.Count > 0)
        {
            SlingShooter.InitiateBird(Birds[0]);
            _shotBird = Birds[0];
        }
        else if (Birds.Count == 0)
        {
            _isGameEnded = true;
            _gameEnd.gameObject.SetActive(true);  <----
        }
    }
.
.
.
public void CheckGameEnd(GameObject destroyedEnemy)
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemies[i].gameObject == destroyedEnemy)
            {
                Enemies.RemoveAt(i);
                break;
            }
        }
        if (Enemies.Count == 0)
        {
            _isGameEnded = true;
            _gameEnd.gameObject.SetActive(true);  <----
        }
    }

3. Penambahan interaksi memulai kembali ketika game sudah selesai

Kode Script End:

using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // reload
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

4. Penambahan gameobject wood dan enemy dalam game supaya lebih menantang

Selebihnya sudah sama dengan tutorial yang diberikan
Terima kasih