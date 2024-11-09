import "./App.css";
import Navbar from "./components/Navbar";
import RegistrationPage from "./pages/RegistrationPage";
import LoginPage from "./pages/LoginPage";
import AboutUs from "./pages/AboutUs";
import Services from "./pages/Services";
import Contacts from "./pages/Contact";
function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Navbar />
        <Contacts />
      </header>
    </div>
  );
}

export default App;
