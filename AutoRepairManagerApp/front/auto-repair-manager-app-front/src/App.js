import "./App.css";
import Navbar from "./components/Navbar";
import AppRoutes from "./Routes";
import Navigation from "./components/Navigation";
function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Navbar />
      </header>
      <Navigation />
      <AppRoutes />
    </div>
  );
}

export default App;
