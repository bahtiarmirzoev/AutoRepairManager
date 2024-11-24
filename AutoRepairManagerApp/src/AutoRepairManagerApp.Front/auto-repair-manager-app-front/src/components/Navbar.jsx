import React from "react";
import { Link } from "react-router-dom";

const handleLogout = async () => {
  try {
    localStorage.removeItem("userToken");
    // const response = await fetch("http://localhost:5271/api/Identity/Logout", {
    //   method: "POST"
    // });

    // if (response.ok) {
    //   console.log("Logged out successfully");

    window.location.href = "/LoginPage";
    // } else {
    //   console.error("Failed to log out");
    // }
  } catch (error) {
    console.error("Error during logout:", error);
  }
};

const Navbar = () => {
  // Check if userToken exists in localStorage
  const userToken = localStorage.getItem("userToken");

  return (
    <nav className="bg-white shadow-lg fixed w-full z-10">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex justify-between items-center h-16">
          <div className="flex-shrink-0">
            <Link to="/" className="text-2xl font-bold text-blue-600">
              Paputu Service
            </Link>
          </div>

          <div className="hidden md:flex space-x-8">
            <Link
              to="/"
              className="text-gray-700 hover:text-blue-600 transition duration-200"
            >
              Главная
            </Link>
            <Link
              to="/Services"
              className="text-gray-700 hover:text-blue-600 transition duration-200"
            >
              Услуги
            </Link>
            <Link
              to="/AboutUs"
              className="text-gray-700 hover:text-blue-600 transition duration-200"
            >
              О нас
            </Link>
            <Link
              to="/Contact"
              className="text-gray-700 hover:text-blue-600 transition duration-200"
            >
              Контакты
            </Link>

            <Link
              to="/RepairRequest"
              className="text-gray-700 hover:text-blue-600 transition duration-200"
            >
              Сделать Запрос
            </Link>
          </div>

          <div className="flex items-center space-x-4">
            {userToken ? (
              <>
                <Link
                  to="/Profile"
                  className="text-gray-700 hover:text-blue-600 transition duration-200"
                >
                  Мой профиль
                </Link>
                <button
                  onClick={handleLogout}
                  className="text-gray-700 hover:text-blue-600 transition duration-200"
                >
                  Выйти
                </button>
              </>
            ) : (
              <>
                <Link
                  to="/LoginPage"
                  className="text-gray-700 hover:text-blue-600 transition duration-200"
                >
                  Вход
                </Link>
                <Link
                  to="/RegistrationPage"
                  className="text-gray-700 hover:text-blue-600 transition duration-200"
                >
                  Регистрация
                </Link>
              </>
            )}
          </div>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
