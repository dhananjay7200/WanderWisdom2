
import './App.css';
import HomePage from './Components/Home';
import Login from './Components/UserLogin';
import { BrowserRouter, Routes, Route } from "react-router-dom";
function App() {
  return (
    <BrowserRouter>
    <Routes>
      <Route path="/" element={<Login />}/>
      <Route path='/Home' element={<HomePage/>}/>
       
    </Routes>
 

  </BrowserRouter>
  );
}

export default App;
