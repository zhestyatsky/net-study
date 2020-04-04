﻿using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BoringVector.Tests")]

namespace BoringVector
{
    /// <summary>
    /// Класс для работы с векторами на плоскости
    /// </summary>
    internal struct Vector
    {
        public double X;
        public double Y;

        /// <summary>
        /// Конструирует вектор из двух координат
        /// </summary>
        /// <param name="x">Координата <see cref="double"/> по оси x</param>
        /// <param name="y">Координата <see cref="double"/> по оси y</param>
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        
        /// <summary>
        /// Возвращает <see cref="double"/>, квадрат длины вектора
        /// </summary>
        /// <returns><see cref="double"/>, квадрат длины вектора</returns>
        public double SquareLength()
        {
            return X * X + Y * Y;
        }
        /// <summary>
        /// Складывает заданный <see cref="Vector"/> с текущим и возвращает сумму, <see cref="Vector"/>
        /// </summary>
        /// <param name="v">Прибавляемый <see cref="Vector"/></param>
        /// <returns><see cref="Vector"/>, сумма векторов</returns>
        public Vector Add(Vector v)
        {
            X += v.X;
            Y += v.Y;
            return this;
        }
        /// <summary>
        /// Возвращает текущий <see cref="Vector"/>, умноженный на число <see cref="double"/>
        /// </summary>
        /// <param name="k"><see cref="double"/>, коэффициент умножения</param>
        /// <returns><see cref="Vector"/>, умноженный на число <see cref="double"/></returns>
        public Vector Scale(double k)
        {
            X *= k;
            Y *= k;
            return this;
        }
        /// <summary>
        /// Возвращает <see cref="double"/>, скалярное произведение с заданным <see cref="Vector"/> 
        /// </summary>
        /// <param name="v"><see cref="Vector"/>, на который умножается текущий</param>
        /// <returns><see cref="double"/>, скалярное произведение с заданным <see cref="Vector"/></returns>
        public double DotProduct(Vector v)
        {
            return X * v.X + Y * v.Y;
        }
        /// <summary>
        /// Возвращает <see cref="double"/>, модуль векторного произведения с заданным <see cref="Vector"/> 
        /// </summary>
        /// <param name="v"><see cref="Vector"/>, на который умножается текущий</param>
        /// <returns><see cref="double"/>, модуль векторного произведения с заданным <see cref="Vector"/></returns>
        public double CrossProduct(Vector v)
        {
            return Math.Abs(X * v.Y - Y * v.X);
        }
        /// <summary>
        /// Возвращает <see cref="string"/>, строковое представление <see cref="Vector"/>
        /// </summary>
        /// <returns>Строковое представление <see cref="Vector"/></returns>
        public override string ToString()
        {
            return string.Concat("(", X.ToString(), "; )", Y.ToString(), ")");
        }
        /// <summary>
        /// Складывает два объекта <see cref="Vector"/> и возвращает новый <see cref="Vector"/>
        /// </summary>
        /// <param name="v"><see cref="Vector"/>, левое слагаемое</param>
        /// <param name="u"><see cref="Vector"/>, правое слагаемое</param>
        /// <returns><see cref="Vector"/>, сумма векторов</returns>
        public static Vector operator +(Vector v, Vector u)
        {
            return u.Add(v);
        }
        /// <summary>
        /// Вычитает один <see cref="Vector"/> из другого и возвращает новый <see cref="Vector"/>
        /// </summary>
        /// <param name="v"><see cref="Vector"/>, левое слагаемое</param>
        /// <param name="u"><see cref="Vector"/>, правое слагаемое</param>
        /// <returns><see cref="Vector"/>, результат вычитания</returns>
        public static Vector operator -(Vector v, Vector u)
        {
            return new Vector(v.X - u.X, v.Y - u.Y);
        }
        /// <summary>
        /// Возвращает <see cref="Vector"/>, умноженный на число <see cref="double"/>
        /// </summary>
        /// <param name="k"><see cref="double"/>, коэффициент умножения</param>
        /// <param name="v">Исходный <see cref="Vector"/></param>
        /// <returns><see cref="Vector"/>, умноженный на число <see cref="double"/></returns>
        public static Vector operator *(double k, Vector v)
        {
            return v.Scale(k);
        }
        /// <summary>
        /// Возвращает <see cref="Vector"/>, умноженный на число <see cref="double"/>
        /// </summary>
        /// <param name="v">Исходный <see cref="Vector"/></param>
        /// <param name="k"><see cref="double"/>, коэффициент умножения</param>
        /// <returns><see cref="Vector"/>, умноженный на число <see cref="double"/></returns>
        public static Vector operator *(Vector v, double k)
        {
            return v.Scale(k);
        }
        /// <summary>
        /// Возвращает <see cref="Vector"/>, нормированный на число <see cref="double"/>
        /// </summary>
        /// <param name="v">Исходный <see cref="Vector"/></param>
        /// <param name="k"><see cref="double"/>, коэффициент нормировки</param>
        /// <returns><see cref="Vector"/>, нормированный на число <see cref="double"/></returns>
        public static Vector operator /(Vector v, double k)
        {
            return v.Scale(1 / k);
        }
        /// <summary>
        /// Позволяет использовать унарный + с <see cref="Vector"/>, не меняет его
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/></param>
        /// <returns>Неизмененный <see cref="Vector"/></returns>
        public static Vector operator +(Vector v)
        {
            return v;
        }
        /// <summary>
        /// Возвращает <see cref="Vector"/>, направленный противоположно данному
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/></param>
        /// <returns><see cref="Vector"/>, направленный противоположно данному</returns>
        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y);
        }
    }

    #region 4. Тесты

    /*
            SquareLength
            Add
            Scale
            DotProduct
            CrossProduct

        Примечание: структура Vector описана как internal структура, поэтому по умолчанию сборке BoringVector.Tests она не видна.
        Чтобы она была видна, существует специальная директива компилятору:
            [assembly: InternalsVisibleTo("XXX")]
        , где XXX - название проекта, которому ты хочешь сделать видимыми свои internal'ы.

        Можешь посмотреть, в задании [01-primitive-types] эта директива есть в файле Program.cs проекта Numbers.
    */

    #endregion


    /*
        На этом все. Время делать пулл реквест и наслаждаться заслуженным отдыхом :)
    */
}
