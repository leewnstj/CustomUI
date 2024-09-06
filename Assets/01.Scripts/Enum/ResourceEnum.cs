// 새로 알게된 내용 :
// enum의 기본 데이터 형은 int이다.
// 하지만 우리는 enum을 사용하면서 -2,147,483,648 ~ 2,147,483,647까지의 값을 쓰지 않는다.
// 데이터 형식을 int보다 작은 값을 상속 받는게 효율적이다.


public enum ResourceType : byte
{
    None = 0,

    Coin,
    Gem,
}