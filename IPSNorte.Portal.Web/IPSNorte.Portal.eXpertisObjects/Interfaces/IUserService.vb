Public interface IUserService
    Function RegisterNewUser(user As User) As Boolean
    
    Function FindByName(username As String) As User

    Function FindById(id As String) As User

    Sub Update(user As User)

    Sub Delete(user As User)

    Function GetCurrentUser() As User

end interface