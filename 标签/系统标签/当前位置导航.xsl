<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ms="urn:schemas-microsoft-com:xslt" xmlns:lewi="http://www.powereasy.net" xmlns:pe="labelproc" exclude-result-prefixes="pe ms lewi">
    <xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>
    <xsl:param name="nodeId" />
    <xsl:param name="displayNodeTips" />
    <xsl:param name="linkOpenType" />
    <xsl:param name="currentId" />
    <xsl:param name="splitChar" />
    <xsl:template match="/NewDataSet/Table">
        <xsl:if test="count(/NewDataSet/Table) &gt; 0">
            {PE.Label id="当前位置导航" nodeId="<xsl:value-of select="ParentID"/>" currentId="$nodeId" /}
        </xsl:if>
        <xsl:if test="ShowOnPath = 'true'">
            <li>
                <xsl:attribute name="class">breadcrumb-item</xsl:attribute>
                <a>
                    <xsl:attribute name="href">
                        <xsl:choose>
                            <xsl:when test="NodeType = 4">
                                <xsl:value-of select="LinkUrl"/>
                            </xsl:when>
                            <xsl:otherwise>
                                <xsl:value-of select="pe:GetNodePath(false,NodeID)"/>
                            </xsl:otherwise>
                        </xsl:choose>
                    </xsl:attribute>
                    <xsl:attribute name="target">
                        <xsl:choose>
                            <xsl:when test="$linkOpenType = 2">
                                <xsl:choose>
                                    <xsl:when test="pe:GetNodeFieldName(NodeID,'OpenType') = 0">_self</xsl:when>
                                    <xsl:otherwise>_blank</xsl:otherwise>
                                </xsl:choose>
                            </xsl:when>
                            <xsl:when test="$linkOpenType = 1">_blank</xsl:when>
                            <xsl:when test="$linkOpenType = 0">_self</xsl:when>
                            <xsl:otherwise>
                                <xsl:value-of select="$linkOpenType"/>
                            </xsl:otherwise>
                        </xsl:choose>
                    </xsl:attribute>
                    <xsl:if test="$displayNodeTips = 'true'">
                        <xsl:attribute name="title">
                            <xsl:value-of select="Tips" />
                        </xsl:attribute>
                    </xsl:if>
                    <xsl:value-of select="NodeName"/>
                </a>
            </li>
        </xsl:if>
    </xsl:template>
</xsl:stylesheet>
