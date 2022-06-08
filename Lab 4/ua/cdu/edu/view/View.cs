namespace Lab_4.ua.cdu.edu.view
{
    public interface View<E, T>
    {
        public E Bind();
        public void Render(T item);
    }
}
