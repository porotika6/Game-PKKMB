using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Dipasang di scene MainMenu, pada GameObject CharactersMenuUI.
// Alur: klik karakter di grid -> popup muncul -> tombol Select (pilih sementara) / Close (batal)
// -> tombol Confirm di panel (di luar popup) -> simpan permanen & kembali ke MainMenu.
public class CharacterSelectManager : MonoBehaviour
{
    [Header("Sumber data karakter")]
    public CharacterDatabase database;

    [Header("Grid karakter")]
    public Button[] characterButtons; // Character1..Character5

    [Header("Popup detail karakter")]
    public GameObject popupPanel;
    public Image popupCharacterImage;     // objek "Character" di dalam PopupPanel
    public TMP_Text popupDescriptionText; // objek "Description" di dalam PopupPanel
    public Button popupSelectButton;      // tombol "Select" di dalam popup -> pilih karakter ini sementara
    public Button popupCloseButton;       // tombol "Close" di dalam popup -> batal, tutup popup saja

    [Header("Panel Characters")]
    public Button panelConfirmButton;     // tombol "Confirm" di CharactersPanel (di luar popup)
    public GameObject charactersMenuUI;   // root UI Characters, disembunyikan setelah confirm
    public GameObject mainMenuUI;         // root UI MainMenu, ditampilkan setelah confirm

    [Header("Dim Effect")]
    [Range(0f, 1f)] public float dimAlpha = 0.4f;

    private CanvasGroup[] _characterGroups;
    private int _popupIndex;    // karakter yang sedang dibuka di popup
    private int _pendingIndex;  // karakter yang sudah ditekan "Select", belum final
    private int _selectedIndex; // karakter yang sudah final tersimpan (dari sesi sebelumnya)

    void Start()
    {
        _selectedIndex = database.GetSelectedIndex();
        _pendingIndex = _selectedIndex;
        _characterGroups = new CanvasGroup[characterButtons.Length];

        for (int i = 0; i < characterButtons.Length; i++)
        {
            int index = i; // wajib disalin ke variabel lokal agar closure tidak salah nangkap index terakhir
            characterButtons[i].onClick.AddListener(() => OpenPopup(index));

            CanvasGroup group = characterButtons[i].GetComponent<CanvasGroup>();
            if (group == null) group = characterButtons[i].gameObject.AddComponent<CanvasGroup>();
            _characterGroups[i] = group;
        }

        popupSelectButton.onClick.AddListener(OnPopupSelect);
        popupCloseButton.onClick.AddListener(ClosePopup);
        panelConfirmButton.onClick.AddListener(OnPanelConfirm);

        popupPanel.SetActive(false);
        RefreshDimming();
    }

    // Klik salah satu karakter di grid -> buka popup detail karakter itu
    void OpenPopup(int index)
    {
        _popupIndex = index;
        CharacterData c = database.characters[index];
        popupCharacterImage.sprite = c.icon;
        popupDescriptionText.text = c.popupDescription;
        popupPanel.SetActive(true);
    }

    // Tombol "Select" di dalam popup -> jadikan pilihan sementara, tutup popup, highlight grid
    void OnPopupSelect()
    {
        _pendingIndex = _popupIndex;
        ClosePopup();
        RefreshDimming();
    }

    // Tombol "Close" di dalam popup -> batal, tidak mengubah pilihan sementara
    void ClosePopup()
    {
        popupPanel.SetActive(false);
    }

    // Tombol "Confirm" di CharactersPanel -> simpan permanen, tutup UI Characters, balik ke MainMenu
    void OnPanelConfirm()
    {
        database.SetSelectedIndex(_pendingIndex);
        _selectedIndex = _pendingIndex;

        charactersMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    // Karakter yang sedang di-highlight (tentative, sebelum tombol Confirm ditekan)
    void RefreshDimming()
    {
        for (int i = 0; i < _characterGroups.Length; i++)
            _characterGroups[i].alpha = (i == _pendingIndex) ? 1f : dimAlpha;
    }
}