import Login from './pages/Login';
import { Route, Routes } from 'react-router';
function App() {
  return (
    <>
      <Routes>
        <Route path='/' element={<Login />}/>
      </Routes>
    </>
  )
}

export default App;
