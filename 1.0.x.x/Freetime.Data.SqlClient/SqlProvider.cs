/////////////////////////////////////////////////////////////////////////////////////////////////////
// Original Code by : Michael Dela Cuesta (michael.dcuesta@gmail.com)                              //
// Source Code Available : http://anito.codeplex.com                                               //
//                                                                                                 // 
// This source code is made available under the terms of the Microsoft Public License (MS-PL)      // 
///////////////////////////////////////////////////////////////////////////////////////////////////// 

using System;
using System.Security.Permissions;
using Anito.Data;
using Freetime.Authentication;
using Freetime.Base.Data.Entities.Common;

namespace Freetime.Data.SqlClient
{
    [type: ReflectionPermission(SecurityAction.Assert, ReflectionEmit = true)]
    public class SqlProvider : ProviderBase, IUserable
    {
        #region Variables
        private readonly Mapper m_mapper;
        private readonly CommandBuilder m_builder;
        private readonly CommandExecutor m_executor;
        #endregion


        private const string PROVIDER_NAME = "Freetime.Data.SqlClient";

        #region Properties

        #region ConnectionString
        public override string ConnectionString
        {
            get
            {
                return m_executor.ConnectionString;
            }
            set
            {
                m_executor.ConnectionString = value;
            }
        }
        #endregion

        #region CommandBuilder
        public override ICommandBuilder CommandBuilder
        {
            get
            {
                return m_builder;
            }
        }
        #endregion

        #region Mapper
        public override IMapper Mapper
        {
            get
            {
                return m_mapper;
            }
        }
        #endregion

        #region CommandExecutor
        public override ICommandExecutor CommandExecutor
        {
            get
            {
                return m_executor;
            }
        }
        #endregion

        #endregion

        #region Methods

        #region Constructor
        public SqlProvider() 
            : base(PROVIDER_NAME)
        {
            m_mapper = new Mapper(this);
            m_builder = new CommandBuilder(this);           
            m_executor = new CommandExecutor();
        }
        #endregion

        #region Dispose
        public virtual void Dispose()
        {

        }
        #endregion

        #endregion

        public FreetimeUser CurrentUser { get; set; }

        public override EntityStatus GetEntityStatus(object item)
        {
            var entityStatus = base.GetEntityStatus(item);

            if (!typeof(AuditableEntity).IsAssignableFrom(item.GetType()))
                return entityStatus;

            var auditable = item as AuditableEntity;

            if (Equals(auditable, null))
                return entityStatus;

            switch (entityStatus)
            {
                case EntityStatus.Insert:
                    auditable.UserCreated = CurrentUser.UserId;
                    auditable.DateCreated = DateTime.UtcNow;
                    break;
                case EntityStatus.Update:
                    auditable.UserModified = CurrentUser.UserId;
                    auditable.DateModified = DateTime.UtcNow;
                    break;
                case EntityStatus.Delete:
                    auditable.UserModified = CurrentUser.UserId;
                    auditable.DateModified = DateTime.UtcNow;
                    break;
            }
            return entityStatus;
        }

    }
}
