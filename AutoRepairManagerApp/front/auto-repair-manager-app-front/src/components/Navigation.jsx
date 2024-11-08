import { Link } from "react-router-dom";

function Navigation() {
  return (
    <nav>
      <Link to="/login">Login</Link>
      <Link to="/registration">Registration</Link>
    </nav>
  );
}

export default Navigation;
