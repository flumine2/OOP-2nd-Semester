namespace Lab_4.ua.cdu.edu.view
{
    public interface IView<E, T>
    {
        public E Bind();
        public void Render(T item);
    }
}
