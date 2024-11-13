import React from "react";
import { Link } from "react-router-dom";

const Navbar = () => {
  return (
    <div className="bg-gray-800 text-white h-full p-4">
      <div className="flex flex-col space-y-4">
        <div className="text-2xl font-bold mb-6">Админ Панель</div>
        <nav className="space-y-4">
          <Link
            to="/admin/users"
            className="hover:bg-gray-700 px-4 py-2 rounded-md transition-colors"
          >
            Управление Пользователями
          </Link>
          <Link
            to="/admin/cars"
            className="hover:bg-gray-700 px-4 py-2 rounded-md transition-colors"
          >
            Управление Машинами
          </Link>
          <Link
            to="/admin/services"
            className="hover:bg-gray-700 px-4 py-2 rounded-md transition-colors"
          >
            Управление Сервисами
          </Link>
          <Link
            to="/admin/queue"
            className="hover:bg-gray-700 px-4 py-2 rounded-md transition-colors"
          >
            Управление Очередью
          </Link>
        </nav>
      </div>
    </div>
  );
};

export default Navbar;
