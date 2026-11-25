using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public sealed class GorselliSoruEtkilesimi : MonoBehaviour
{
    [FormerlySerializedAs("odaSorusuGorseli")]
    [SerializeField] private Sprite roomImage;

    private TMP_InputField answerInput;
    private TMP_Text resultText;
    private GameObject answerPanel;

    private void Start()
    {
        Image room = GetComponent<Image>();
        if (roomImage == null || room == null) return;

        room.sprite = roomImage;
        room.color = Color.white;
        room.preserveAspect = false;
        room.raycastTarget = false;

        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas == null || FindAnyObjectByType<EventSystem>() == null) return;

        TMP_Text fontSource = canvas.GetComponentInChildren<TMP_Text>(true);
        TMP_FontAsset font = fontSource != null ? fontSource.font : TMP_Settings.defaultFontAsset;
        CreateCashRegisterButton(transform);
        CreateAnswerPanel(transform, font);
        answerInput.onSubmit.AddListener(_ => CheckAnswer());
    }

    private void CreateCashRegisterButton(Transform parent)
    {
        Button button = CreateButton(parent, "Cash Register", new Color(1f, 1f, 1f, 0f));
        RectTransform rect = button.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0.54f, 0.49f);
        rect.anchorMax = new Vector2(0.68f, 0.69f);
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
        button.onClick.AddListener(OpenAnswerPanel);
    }

    private void CreateAnswerPanel(Transform parent, TMP_FontAsset font)
    {
        answerPanel = new GameObject("Answer Panel", typeof(RectTransform), typeof(Image));
        answerPanel.transform.SetParent(parent, false);

        RectTransform panelRect = answerPanel.GetComponent<RectTransform>();
        panelRect.anchorMin = new Vector2(0.5f, 0.5f);
        panelRect.anchorMax = new Vector2(0.5f, 0.5f);
        panelRect.sizeDelta = new Vector2(560f, 310f);
        answerPanel.GetComponent<Image>().color = new Color(0.055f, 0.075f, 0.13f, 0.97f);

        CreateText(answerPanel.transform, "Title", "Cevabını gir", font,
            new Vector2(0.05f, 0.77f), new Vector2(0.95f, 0.96f), 30f, TextAlignmentOptions.Center);

        answerInput = CreateInput(answerPanel.transform, font);
        Button submitButton = CreateButton(answerPanel.transform, "Check Answer", new Color(0.95f, 0.55f, 0.13f, 1f));
        SetAnchors(submitButton.GetComponent<RectTransform>(), new Vector2(0.16f, 0.25f), new Vector2(0.84f, 0.45f));
        CreateText(submitButton.transform, "Button Text", "Cevabı kontrol et", font,
            Vector2.zero, Vector2.one, 22f, TextAlignmentOptions.Center);
        submitButton.onClick.AddListener(CheckAnswer);

        resultText = CreateText(answerPanel.transform, "Result", "", font,
            new Vector2(0.06f, 0.04f), new Vector2(0.94f, 0.22f), 20f, TextAlignmentOptions.Center);

        Button closeButton = CreateButton(answerPanel.transform, "Close", new Color(0.23f, 0.27f, 0.37f, 1f));
        SetAnchors(closeButton.GetComponent<RectTransform>(), new Vector2(0.84f, 0.82f), new Vector2(0.96f, 0.96f));
        CreateText(closeButton.transform, "Close Text", "X", font,
            Vector2.zero, Vector2.one, 19f, TextAlignmentOptions.Center);
        closeButton.onClick.AddListener(() => answerPanel.SetActive(false));

        answerPanel.SetActive(false);
    }

    private TMP_InputField CreateInput(Transform parent, TMP_FontAsset font)
    {
        GameObject inputObject = new GameObject("Answer Input", typeof(RectTransform), typeof(Image), typeof(TMP_InputField));
        inputObject.transform.SetParent(parent, false);
        SetAnchors(inputObject.GetComponent<RectTransform>(), new Vector2(0.12f, 0.52f), new Vector2(0.88f, 0.72f));

        Image background = inputObject.GetComponent<Image>();
        background.color = Color.white;

        TMP_InputField input = inputObject.GetComponent<TMP_InputField>();
        input.targetGraphic = background;
        input.lineType = TMP_InputField.LineType.SingleLine;
        input.contentType = TMP_InputField.ContentType.Standard;
        input.selectionColor = new Color(0.25f, 0.48f, 0.85f, 0.5f);

        TMP_Text valueText = CreateText(inputObject.transform, "Answer Text", "", font,
            new Vector2(0.03f, 0.05f), new Vector2(0.97f, 0.95f), 24f, TextAlignmentOptions.Left);
        valueText.color = new Color(0.08f, 0.08f, 0.08f, 1f);

        TMP_Text placeholder = CreateText(inputObject.transform, "Placeholder", "Cevabını yaz", font,
            new Vector2(0.03f, 0.05f), new Vector2(0.97f, 0.95f), 22f, TextAlignmentOptions.Left);
        placeholder.color = new Color(0.45f, 0.45f, 0.45f, 1f);

        input.textComponent = valueText;
        input.placeholder = placeholder;
        input.text = string.Empty;
        return input;
    }

    private static TMP_Text CreateText(Transform parent, string objectName, string text,
        TMP_FontAsset font, Vector2 anchorMin, Vector2 anchorMax, float fontSize, TextAlignmentOptions alignment)
    {
        GameObject textObject = new GameObject(objectName, typeof(RectTransform), typeof(TextMeshProUGUI));
        textObject.transform.SetParent(parent, false);
        SetAnchors(textObject.GetComponent<RectTransform>(), anchorMin, anchorMax);

        TMP_Text label = textObject.GetComponent<TMP_Text>();
        label.text = text;
        label.font = font;
        label.fontSize = fontSize;
        label.alignment = alignment;
        label.color = Color.white;
        label.raycastTarget = false;
        label.enableAutoSizing = true;
        label.fontSizeMin = fontSize * 0.7f;
        label.fontSizeMax = fontSize;
        return label;
    }

    private static Button CreateButton(Transform parent, string objectName, Color color)
    {
        GameObject buttonObject = new GameObject(objectName, typeof(RectTransform), typeof(Image), typeof(Button));
        buttonObject.transform.SetParent(parent, false);
        Image image = buttonObject.GetComponent<Image>();
        image.color = color;
        image.raycastTarget = true;

        Button button = buttonObject.GetComponent<Button>();
        button.targetGraphic = image;
        button.transition = Selectable.Transition.ColorTint;
        return button;
    }

    private static void SetAnchors(RectTransform rect, Vector2 min, Vector2 max)
    {
        rect.anchorMin = min;
        rect.anchorMax = max;
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
    }

    private void OpenAnswerPanel()
    {
        resultText.text = string.Empty;
        answerInput.text = string.Empty;
        answerPanel.SetActive(true);
        answerInput.Select();
        answerInput.ActivateInputField();
    }

    public void SetRoomImage(Sprite image)
    {
        roomImage = image;
        Image room = GetComponent<Image>();
        if (room != null && roomImage != null)
        {
            room.sprite = roomImage;
            room.color = Color.white;
            room.preserveAspect = false;
        }
    }

    private void CheckAnswer()
    {
        string enteredAnswer = answerInput.text;
        bool answerExists;
        if (CevapKontrolEdici.CevabiKontrolEt(enteredAnswer, out answerExists))
        {
            answerInput.text = string.Empty;
            CevapKontrolEdici.AnaMenuyeDon();
            return;
        }

        resultText.text = answerExists ? "Cevap doğru değil, tekrar dene." : "Bu konuya henüz cevap eklenmedi.";
        answerInput.Select();
        answerInput.ActivateInputField();
    }
}
