namespace BusinessLogic.ValidationModels
{
    public interface IValidationModel<out T>
    {

        //**************************************************
        //* Public
        //**************************************************

        //--------------------------------------------
        T ToModel();

    }
}