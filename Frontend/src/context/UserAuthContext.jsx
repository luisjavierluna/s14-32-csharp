import { createContext, useState, useContext } from 'react'

const UserAuthContext = createContext()

export const UserAuthProvider = ({ children }) => {
  const [userName, setUserName] = useState(null)
  
  const handleLogin = (userData) => {
    const { token, user } = userData    
    localStorage.setItem('token', token)  
    localStorage.setItem('userName', user.firstName)      
    setUserName(user.firstName)
    console.log(user)
    console.log(user.firstName) 
  }

  const handleLogout = () => {    
    localStorage.removeItem('token')
    localStorage.removeItem('userName')    
    setUserName(null)
  }
    

  return (
    <UserAuthContext.Provider value={{ userName, handleLogin, handleLogout }}>
      {children}
    </UserAuthContext.Provider>
  )
}

export const useUserAuth = () => {
  return useContext(UserAuthContext)
}