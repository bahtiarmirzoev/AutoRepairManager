import React, { useState } from "react";
import { FaUserCircle } from "react-icons/fa";
import { Link } from "react-router-dom";
const Navbar = () => {
  const [dropdownOpen, setDropdownOpen] = useState(false);

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
              to="/Home"
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
          </div>

          {/* Иконки для авторизации и профиля */}
          <div className="flex items-center space-x-4">
            <button className="text-gray-700 hover:text-blue-600 transition duration-200">
              Вход
            </button>
            <button className="text-gray-700 hover:text-blue-600 transition duration-200">
              Регистрация
            </button>

            {/* Профиль пользователя с выпадающим меню */}
            <div className="relative">
              <button
                onClick={() => setDropdownOpen(!dropdownOpen)}
                className="text-gray-700 hover:text-blue-600 transition duration-200"
              >
                <FaUserCircle size={24} />
              </button>
              {dropdownOpen && (
                <div className="absolute right-0 mt-2 w-48 bg-white border border-gray-200 rounded-lg shadow-lg">
                  <Link
                    to="#"
                    className="block px-4 py-2 text-gray-700 hover:bg-gray-100"
                  >
                    Профиль
                  </Link>
                  <Link
                    to="#"
                    className="block px-4 py-2 text-gray-700 hover:bg-gray-100"
                  >
                    Настройки
                  </Link>
                  <button className="w-full text-left px-4 py-2 text-gray-700 hover:bg-gray-100">
                    Выход
                  </button>
                </div>
              )}
            </div>
          </div>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
