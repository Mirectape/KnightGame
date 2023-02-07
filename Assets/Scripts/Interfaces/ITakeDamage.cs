
public interface ITakeDamage
{
    void TakeDamage(float damage); // An entity should take damage
                                   // describe how
    void CheckIfIsAlive(); // In TakeDamage Check if an entity is alive
    void Die(); // If not, play an animation of dying and realize destruction off the scene
   
}
