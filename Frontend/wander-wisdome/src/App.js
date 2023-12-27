
import './App.css';
import HomePage from './Components/Home';
import Login from './Components/UserLogin';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import UserRegistration from './Components/UserRegistration';
import UserProfile from './Components/UserProfile';
import AddPost from './Components/AddPost';
function App() {
  return (
    <BrowserRouter>
    <Routes>
      <Route path="/" element={<Login />}/>
      <Route path='/Home' element={<HomePage/>}/>
      <Route path='/register' element={<UserRegistration/>}/>
     <Route path='/profile' element={<UserProfile/>}/>
     <Route path='/post' element={<AddPost/>}/>
       
    </Routes>
 

  </BrowserRouter>
  );
}

export default App;
