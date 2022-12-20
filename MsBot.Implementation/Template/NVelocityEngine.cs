using MsBot.Infrastructure;
using NVelocity;
using NVelocity.App;
using NVelocity.Runtime;
using System.Collections;

namespace MsBot.Implementation.Template
{
    /// <summary>
    /// NVelocity引擎
    /// </summary>
    public class NVelocityEngine
    {
        private readonly VelocityEngine _engine;
        private VelocityContext _context;

        /// <summary>
        /// 创建NVelocity引擎
        /// </summary>
        /// <param name="templatePath">模板文件路径</param>
        public NVelocityEngine(string templatePath)
        {
            TemplatePath = templatePath;
            _engine = new VelocityEngine();
            _engine.SetProperty(RuntimeConstants.RESOURCE_LOADER, "file");
            _engine.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, templatePath);
            _engine.Init();
        }

        /// <summary>
        /// 创建NVelocity引擎
        /// </summary>
        public NVelocityEngine() : this(string.Empty)
        {
        }

        /// <summary>
        /// 创建NVelocity引擎
        /// </summary>
        /// <param name="templatePath">模板文件路径</param>
        public static NVelocityEngine Create(string templatePath)
        {
            return new NVelocityEngine(templatePath);
        }

        /// <summary>
        /// 创建NVelocity引擎
        /// </summary>
        public static NVelocityEngine Create()
        {
            return new NVelocityEngine();
        }

        private VelocityContext Context
        {
            get
            {
                if (_context != null)
                    return _context;
                _context = new VelocityContext();

                #region Helpers
                _context.Put("ObjectHelper", ObjectHelper.Instance);
                _context.Put("RequestHelper", RequestHelper.Instance);
                _context.Put("SerializerHelper", SerializerHelper.Instance);
                #endregion
                return _context;
            }
        }

        /// <summary>
        /// 模板路径
        /// </summary>
        public string TemplatePath { get; }

        /// <summary>
        /// 解析模板
        /// </summary>
        /// <param name="fileName">模板路径</param>
        /// <param name="bags">变量集合</param>
        /// <returns></returns>
        public string AccessTemplate(string fileName, Hashtable bags)
        {
            if (bags != null)
            {
                foreach (string key in bags.Keys)
                    Context.Put(key, bags[key]);
            }

            var template = _engine.GetTemplate(fileName, "UTF-8");
            var writer = new StringWriter();
            template.Merge(_context, writer);
            return writer.GetStringBuilder().ToString();
        }

        /// <summary>
        /// 解析模板
        /// </summary>
        /// <param name="templateContent">模板内容</param>
        /// <param name="bags">变量集合</param>
        public string Evaluate(string templateContent, Hashtable bags)
        {
            if (bags != null)
            {
                foreach (string key in bags.Keys)
                    Context.Put(key, bags[key]);
            }

            var writer = new StringWriter();
            _engine.Evaluate(_context, writer, "", templateContent);
            return writer.GetStringBuilder().ToString();
        }
    }
}