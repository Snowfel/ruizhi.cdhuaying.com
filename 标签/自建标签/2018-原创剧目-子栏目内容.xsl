<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:pe="labelproc" exclude-result-prefixes="pe">
  <xsl:param name="nodeid"/>
  <xsl:param name="currentid"/>
  <xsl:output method="html"/>
  <xsl:template match="/NewDataSet">
    <xsl:choose>
      <xsl:when test="count(Table) = 0">
      </xsl:when>
      <xsl:otherwise>
        <div>
          <xsl:attribute name="class">tab-pane fade show
            <xsl:if test="$nodeid = $currentid">active</xsl:if>
          </xsl:attribute>
          <xsl:attribute name="id">pills-home-<xsl:value-of select="$nodeid"/>
          </xsl:attribute>
          <xsl:attribute name="role">tabpanel</xsl:attribute>
          <xsl:attribute name="aria-labelledby">pills-home-tab</xsl:attribute>
          <div>
            <xsl:attribute name="class">m-video mx-3 pb-4</xsl:attribute>
            <div>
              <xsl:attribute name="class">row</xsl:attribute>
              <div>
                <xsl:attribute name="class">col-sm-6 px-0</xsl:attribute>
                <div>
                  <xsl:attribute name="class">u-video</xsl:attribute>
                  <xsl:attribute name="style">background: url(/public/images/event/img-09.png) center 0 no-repeat;
                    height: 418px;
                  </xsl:attribute>
                  {PE.Label id="自设内容" nodeid="<xsl:value-of select="$nodeid"/>" num="1" /}
                </div>
              </div>
              <div>
                <xsl:attribute name="class">col-sm-6 m-content pt-5</xsl:attribute>
                <h3>
                  <xsl:attribute name="class">px-3</xsl:attribute>
                  <xsl:value-of select="Table/Tips"/> — 节选
                </h3>
                <div>
                  <xsl:attribute name="class">py-3 px-3</xsl:attribute>
                  剧情介绍：
                  <br/>
                  {PE.Label id="自设内容" nodeid="<xsl:value-of select="$nodeid"/>" num="2" /}
                </div>
              </div>
            </div>
          </div>
          <div>
            <xsl:attribute name="class">m-performer</xsl:attribute>
            <h1>
              <xsl:attribute name="class">m-block-title</xsl:attribute>
              <xsl:value-of select="Table/Tips"/>演员表
            </h1>
            <div class="row">
              {pe.label id="2018-演员照片-图片循环" nodeid="<xsl:value-of select="$nodeid"/>" /}
            </div>
          </div>

          <div>
            <xsl:attribute name="class">m-photo</xsl:attribute>
            <div>
              <xsl:attribute name="class">row m-photo-1 my-3</xsl:attribute>
              <div>
                <xsl:attribute name="class">col</xsl:attribute>
                <div>
                  <xsl:attribute name="class">m-info h-100 card-img</xsl:attribute>
                  <p></p>
                  <h3>演职人员名单</h3>
                  <div>
                    {PE.Label id="自设内容" nodeid="<xsl:value-of select="$nodeid"/>" num="3" /}
                  </div>
                </div>
              </div>
              <div>
                <div>
                  <img>
                    <xsl:attribute name="class">card-img</xsl:attribute>
                    <xsl:attribute name="src">/public/images/event/img-02.png</xsl:attribute>
                  </img>
                </div>
              </div>
            </div>


            <div>
              <xsl:attribute name="class">m-photo-slide my-3</xsl:attribute>
              <div>
                <xsl:attribute name="id">centerwell</xsl:attribute>
                <xsl:attribute name="class">m-slide</xsl:attribute>
                <div>
                  <xsl:attribute name="class">s</xsl:attribute>
                  <xsl:attribute name="style">background: url(/public/images/event/img-03.png) no-repeat;</xsl:attribute>
                  <div>
                    <xsl:attribute name="class">mask d-none</xsl:attribute>
                  </div>
                </div>
                <div>
                  <xsl:attribute name="class">s</xsl:attribute>
                  <xsl:attribute name="style">background: url(/public/images/event/img-04.png) no-repeat;</xsl:attribute>
                  <div>
                    <xsl:attribute name="class">mask</xsl:attribute>
                  </div>
                </div>
                <div>
                  <xsl:attribute name="class">s</xsl:attribute>
                  <xsl:attribute name="style">background: url(/public/images/event/img-05.png) no-repeat;</xsl:attribute>
                  <div>
                    <xsl:attribute name="class">mask</xsl:attribute>
                  </div>
                </div>
              </div>
            </div>

            <div>
              <xsl:attribute name="class">row m-photo-3 my-3</xsl:attribute>
              <div>
                <xsl:attribute name="class">col</xsl:attribute>
              </div>
            </div>

          </div>

        </div>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
</xsl:stylesheet>