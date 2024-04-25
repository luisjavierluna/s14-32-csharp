import { createContext, useState, useContext } from 'react'

const UserAuthContext = createContext()

export const UserAuthProvider = ({ children }) => {
  const [userName, setUserName] = useState(null)
  
  const handleLogin = (userData) => {
    const { token, user } = userData       
    localStorage.setItem('token', token)  
    localStorage.setItem('userName', user.firstName)
    localStorage.setItem('role', user.role)
    localStorage.setItem('profileImage', user.profileImage)         
    localStorage.setItem('contractorProfileImage', user.contractor.profileImage)
    localStorage.setItem('userId', user.id)
    localStorage.setItem('vocations', JSON.stringify(user.contractor.vocations))       
    setUserName(user.firstName)
    console.log(user)
    console.log(user.firstName) 
  }

  const handleLogout = () => {    
    localStorage.removeItem('token')
    localStorage.removeItem('userName')
    localStorage.removeItem('role') 
    localStorage.removeItem('profileImage')
    localStorage.removeItem('contractorProfileImage') 
    localStorage.removeItem('userId') 
    localStorage.removeItem('vocations') 
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