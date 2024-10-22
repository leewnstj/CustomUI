/// <summary>
/// UI객체 업데이트
/// </summary>
public interface IUIUpdater
{
    /// <summary>
    /// UI객체의 타입
    /// </summary>
    public UIType Type { get; }

    /// <summary>
    /// UI객체의 키
    /// </summary>
    public string Key { get; }

    /// <summary>
    /// 업데이트 매서드
    /// </summary>
    /// <param name="content">업데이트 내용</param>
    public void UpdateHandler(object content);
}

public enum UIType : byte
{
    None = 0,

    Resource,
    Stat,
}