namespace ACTIVITY_CONNECTED
{
    /// <summary>
    ///  Game 종류
    ///  movechallenge
    ///  pacer
    ///  
    ///  ResultAll에서 형변환으로 사용
    /// </summary>
    interface IGame
    {
        /// <summary>
        /// 게임 결과 엑셀 저장
        /// </summary>
        void SaveGame();

        /// <summary>
        /// WndProc에서 호출하는 게임 규칙
        /// </summary>
        void GameRule();
    }
}
