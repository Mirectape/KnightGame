
public interface ICharacterMovement 
{
    void Jump(); // How a character jumps
    void JumpConditions(); // When 
    void HorizontalMove(float direction); // How it moves right and left
    void Move(float direction, bool isJumpButtonPressed); // Horizontal moving and jumping and what-not are to be put it Move(...)

}
